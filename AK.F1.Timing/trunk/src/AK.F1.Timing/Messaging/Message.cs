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
using System.Globalization;
using System.Text;

using AK.F1.Timing.Messaging;

namespace AK.F1.Timing.Messaging
{
    /// <summary>
    /// Defines the base class for live timing messages. This class is <see langword="abstract"/>.
    /// </summary>
    [Serializable]
    public abstract class Message
    {        
        #region Public Interface.

        /// <summary>
        /// Defines an empty message. This field is <see langword="readonly"/>.
        /// </summary>
        public static readonly Message Empty = new EmptyMessage();

        /// <summary>
        /// Accepts the specified <see cref="AK.F1.Timing.Messaging.IMessageVisitor"/>.
        /// </summary>
        /// <param name="visitor">The message visitor.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="visitor"/> is <see langword="null"/>.
        /// </exception>
        public abstract void Accept(IMessageVisitor visitor);

        #endregion

        #region Protected Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="Message"/> class.
        /// </summary>
        protected Message() { }

        /// <summary>
        /// Returns a <see cref="System.String"/> representation of this instance using the
        /// specified format <see cref="System.String"/> and format arguments.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The format arguments.</param>
        /// <returns>A <see cref="System.String"/> representation of this instance using the
        /// specified format <see cref="System.String"/> and format arguments.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="format"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.FormatException">
        /// Thrown when the format of <paramref name="format"/> is invalid.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="format"/> references an argument not contained within
        /// <paramref name="args"/>.
        /// </exception>
        protected string Repr(string format, params object[] args) {

            Guard.NotNull(format, "format");

            StringBuilder sb = new StringBuilder();

            sb.Append(GetType().Name);
            sb.Append("(").AppendFormat(CultureInfo.InvariantCulture, format, args).Append(")");

            return sb.ToString();
        }

        #endregion

        #region Private Impl.

        // This type should not serialized hence it has no TypeId.
        [Serializable]
        private sealed class EmptyMessage : Message
        {
            public override void Accept(IMessageVisitor visitor) { }

            public override string ToString() {

                return Repr("");
            }
        }

        #endregion
    }
}
