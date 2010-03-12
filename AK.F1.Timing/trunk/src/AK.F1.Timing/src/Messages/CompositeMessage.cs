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
using System.Collections.Generic;
using System.Text;

namespace AK.F1.Timing.Messaging.Messages
{
    /// <summary>
    /// Defines a <see cref="AK.F1.Timing.Messaging.Message"/> which is composed of one or more
    /// <see cref="AK.F1.Timing.Messaging.Message"/>s. This class cannot be inherited.
    /// </summary>
    [Serializable]
    public sealed class CompositeMessage : Message
    {
        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="CompositeMessage"/> class and specifies
        /// the composite messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="messages"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="messages"/> is empty.
        /// </exception>
        public CompositeMessage(params Message[] messages) {

            Guard.NotNullOrEmpty(messages, "messages");

            this.Messages = Array.AsReadOnly(messages);
        }

        /// <inheritdoc />
        public override void Accept(IMessageVisitor visitor) {

            Guard.NotNull(visitor, "visitor");

            foreach(Message message in this.Messages) {
                message.Accept(visitor);
            }
        }

        /// <inheritdoc />
        public override string ToString() {
            
            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            foreach(Message message in this.Messages) {
                if(sb.Length > 1) {
                    sb.Append(", ");
                }
                sb.Append(message);                
            }
            sb.Append("]");

            return Repr(sb.ToString());
        }

        /// <summary>
        /// Gets the collection of <see cref="AK.F1.Timing.Messaging.Message"/>s contained by this
        /// composite message.
        /// </summary>        
        public IList<Message> Messages { get; private set; }

        #endregion
    }
}
