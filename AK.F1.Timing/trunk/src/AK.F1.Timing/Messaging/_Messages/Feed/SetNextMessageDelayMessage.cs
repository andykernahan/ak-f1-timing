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

namespace AK.F1.Timing.Messaging.Messages.Feed
{
    /// <summary>
    /// A message which specifies the delay that should be inserted between the next message. This
    /// class is <see langword="sealed"/>.
    /// </summary>
    [Serializable]
    public sealed class SetNextMessageDelayMessage : Message
    {
        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="SetNextMessageDelayMessage"/> class and
        /// specifies the delay between the next message.
        /// </summary>
        /// <param name="delay">The delay between the next message.</param>        
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="delay"/> is not positive.
        /// </exception>
        public SetNextMessageDelayMessage(TimeSpan delay) {

            Guard.InRange(delay > TimeSpan.Zero, "delay");

            this.Delay = delay;
        }

        /// <inheritdoc />
        public override void Accept(IMessageVisitor visitor) {

            Guard.NotNull(visitor, "visitor");

            visitor.Visit(this);
        }

        /// <inheritdoc />
        public override string ToString() {

            return Repr("Delay='{0}'", this.Delay);
        }

        /// <summary>
        /// Gets the delay between the next message.
        /// </summary>
        public TimeSpan Delay { get; private set; }

        #endregion
    }
}
