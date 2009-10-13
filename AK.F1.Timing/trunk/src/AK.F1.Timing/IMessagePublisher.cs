﻿// Copyright 2009 Andy Kernahan
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

namespace AK.F1.Timing
{
    public interface IMessagePublisher : IDisposable
    {
        /// <summary>
        /// Occurs when a <see cref="AK.F1.Timing.Message"/> is published.
        /// </summary>
        event EventHandler<MessagePublishedEventArgs> MessagePublished;

        /// <summary>
        /// Starts the publising messages.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        /// Thrown when the reader has been disposed of.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when this publisher has already been started.
        /// </exception>
        void Start();

        /// <summary>
        /// Stops publising messages.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">
        /// Thrown when the reader has been disposed of.
        /// </exception>
        void Stop();
    }
}
