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

using System;
using AK.F1.Timing;

namespace log4net
{
    /// <summary>
    /// A drop in replacement for <see cref="log4net.LogManager"/>.
    /// </summary>
    public static class LogManager
    {
        #region Fields.

        private static Func<Type, ILog> _factory = (_) => NullLogger.Instance;

        #endregion

        #region Public Interface.

        /// <summary>
        /// Gets the logger for the specified <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type the logger is bound to.</param>
        /// <returns>An <see cref="log4net.ILog"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="type"/> is <see langword="null"/>.
        /// </exception>
        public static ILog GetLogger(Type type)
        {
            Guard.NotNull(type, "type");

            return _factory(type);
        }

        /// <summary>
        /// Sets the logger factory method.
        /// </summary>
        /// <param name="factory">The logger factory method.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="factory"/> is <see langword="null"/>.
        /// </exception>
        public static void SetFactory(Func<Type, ILog> factory)
        {
            Guard.NotNull(factory, "factory");

            _factory = factory;
        }

        #endregion

        #region Private Impl.

        private sealed class NullLogger : ILog
        {
            public static readonly ILog Instance = new NullLogger();

            public void Debug(object message) { }
            public void DebugFormat(string format, params object[] args) { }
            public void Info(object message) { }
            public void InfoFormat(string format, params object[] args) { }
            public void Error(object message) { }
            public void ErrorFormat(string format, params object[] args) { }
        }

        #endregion
    }
}