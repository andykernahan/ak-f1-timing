// Copyright 2011 Andy Kernahan
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.IO;
using System.Net;
using System.Net.Sockets;
#if SILVERLIGHT
using System;
using System.Threading;
#endif
using AK.F1.Timing.Serialization;

namespace AK.F1.Timing.Proxy
{
    /// <summary>
    /// An <see cref="AK.F1.Timing.IMessageReader"/> which reads <see cref="AK.F1.Timing.Message"/>s
    /// from an enpoint which itself proxies messages read from the live-timing service. This class
    /// cannot be inherited.
    /// </summary>
    public sealed class ProxyMessageReader : MessageReaderBase
    {
        #region Fields.

        private Socket _socket;
        private IObjectReader _reader;
        private readonly IPEndPoint _endpoint;

        /// <summary>
        /// Defines the default proxy port. This field is constant.
        /// </summary>
        public const int DefaultPort = 50192;

        #endregion

        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="ProxyMessageReader"/> class and specifies
        /// the proxy <paramref name="endpoint"/>.
        /// </summary>
        /// <param name="endpoint">The proxy endpoint.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="endpoint"/> is <see langword="null"/>.
        /// </exception>        
        public ProxyMessageReader(IPEndPoint endpoint)
        {
            Guard.NotNull(endpoint, "endpoint");

            _endpoint = endpoint;
        }

        #endregion

        #region Protected Interface.

        /// <inheritdoc/>        
        protected override Message ReadImpl()
        {
            if(_reader == null)
            {
                Connect();
            }
            return _reader.Read<Message>();
        }

        /// <inheritdoc/>
        protected override void DisposeOfManagedResources()
        {
            DisposeOf(_socket);
            DisposeOf(_reader);
            Log.Info("disconnected");
        }

        #endregion

        #region Private Impl.

        private void Connect()
        {
            try
            {
                Log.InfoFormat("connecting: {0}", _endpoint);
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
#if !SILVERLIGHT
                _socket.Connect(_endpoint);
                _reader = new DecoratedObjectReader(new BufferedStream(new NetworkStream(_socket)));
#else
                Connect(_socket, _endpoint);
                _reader = new DecoratedObjectReader(new SocketStream(_socket));
#endif
                Log.Info("connected");
            }
            catch(SocketException exc)
            {
                DisposeOf(_socket);
                Log.Error(exc);
                throw Guard.ProxyMessageReader_FailedToConnect(exc);
            }
        }
#if SILVERLIGHT
        private static void Connect(Socket socket, IPEndPoint endpoint)
        {
            using(var e = new SocketAsyncEventArgs())
            using(var completed = new ManualResetEvent(false))
            {
                e.RemoteEndPoint = endpoint;
                e.UserToken = completed;
                e.Completed += delegate { completed.Set(); };
                if(socket.ConnectAsync(e))
                {
                    completed.WaitOne();
                }
                if(e.SocketError != SocketError.Success)
                {
                    throw new SocketException((int)e.SocketError);
                }
            }
        }

        private sealed class SocketStream : Stream
        {
        #region Fields.

            private readonly Socket _socket;
            private readonly SocketAsyncEventArgs _socketEvent;
            private readonly ManualResetEvent _socketEventCompleted;
            private bool _isDisposed;
            private readonly byte[] _buffer;
            private int _length;
            private int _position;

            #endregion

        #region Public Interface

            public SocketStream(Socket socket)
            {
                _socket = socket;
                _buffer = new byte[4096];
                _socketEvent = new SocketAsyncEventArgs();
                _socketEvent.Completed += OnSocketEventCompleted;
                _socketEvent.SetBuffer(_buffer, 0, _buffer.Length);
                _socketEventCompleted = new ManualResetEvent(false);
            }

            public override int ReadByte()
            {
                CheckDisposed();
                return FillBuffer() ? _buffer[_position++] : -1;
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                CheckDisposed();
                Guard.CheckBufferArgs(buffer, offset, count);

                if(!FillBuffer())
                {
                    return -1;
                }
                if(count == 0)
                {
                    return 0;
                }
                int copy = Math.Min(_length - _position, count);
                Buffer.BlockCopy(_buffer, _position, buffer, offset, copy);
                _position += copy;
                return copy;
            }

            public override void Flush() { }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            public override bool CanRead
            {
                get { return !_isDisposed; }
            }

            public override bool CanSeek
            {
                get { return false; }
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override long Length
            {
                get { throw new NotSupportedException(); }
            }

            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }

            #endregion

        #region Protected Interface.

            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                if(!_isDisposed && disposing)
                {
                    _isDisposed = true;
                    if(_socketEvent != null)
                    {
                        _socketEvent.Completed -= OnSocketEventCompleted;
                        DisposeOf(_socketEvent);
                    }
                    DisposeOf(_socket);
                }
            }

            #endregion

        #region Private Impl.

            private bool FillBuffer()
            {
                if(_length == -1)
                {
                    return false;
                }
                if(_position < _length)
                {
                    return true;
                }
                _length = Receive();
                _position = 0;
                return _length != -1;
            }

            private int Receive()
            {
                try
                {
                    _socketEventCompleted.Reset();
                    if(_socket.ReceiveAsync(_socketEvent))
                    {
                        _socketEventCompleted.WaitOne();
                    }
                    if(_socketEvent.SocketError != SocketError.Success)
                    {
                        throw new SocketException((int)_socketEvent.SocketError);
                    }
                    return _socketEvent.BytesTransferred > 0 ? _socketEvent.BytesTransferred : -1;
                }
                catch(SocketException exc)
                {
                    throw new IOException(exc.Message, exc);
                }
            }

            private void OnSocketEventCompleted(object sender, SocketAsyncEventArgs e)
            {
                _socketEventCompleted.Set();
            }

            private void CheckDisposed()
            {
                if(_isDisposed)
                {
                    throw Guard.ObjectDisposed(this);
                }
            }

            #endregion
        }
#endif
        #endregion
    }
}