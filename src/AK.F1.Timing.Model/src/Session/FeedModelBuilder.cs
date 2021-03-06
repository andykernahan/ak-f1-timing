// Copyright 2010 Andy Kernahan
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
using AK.F1.Timing.Messages.Feed;
using AK.F1.Timing.Utility;

namespace AK.F1.Timing.Model.Session
{
    public partial class FeedModel
    {
        /// <summary>
        /// An <see cref="AK.F1.Timing.IMessageProcessor"/> which builds a
        /// <see cref="AK.F1.Timing.Model.Session.FeedModel"/> as it processes
        /// <see cref="AK.F1.Timing.Message"/>s. This class cannot be inherited.
        /// </summary>
        [Serializable]
        private sealed class FeedModelBuilder : MessageVisitorBase, IMessageProcessor
        {
            #region Public Interface.

            /// <summary>
            /// Initialises a new instance of the <see cref="FeedModelBuilder"/> class and specifies
            /// the <paramref name="model"/> to build.
            /// </summary>
            /// <param name="model">The model to build.</param>
            /// <exception cref="System.ArgumentNullException">
            /// Thrown when <paramref name="model"/> is <see langword="null"/>.
            /// </exception>
            public FeedModelBuilder(FeedModel model)
            {
                Guard.NotNull(model, "model");

                Model = model;
            }

            /// <inheritdoc/>
            public void Process(Message message)
            {
                message.Accept(this);

                ++Model.MessageCount;
                Model.LastMessageReceivedOn = SysClock.Now();
            }

            /// <inheritdoc/>
            public override void Visit(SetCopyrightMessage message)
            {
                Model.Copyright = message.Copyright;
            }

            /// <inheritdoc/>
            public override void Visit(SetKeyframeMessage message)
            {
                Model.KeyframeNumber = message.Keyframe;
            }

            /// <inheritdoc/>
            public override void Visit(SetPingIntervalMessage message)
            {
                Model.PingInterval = message.PingInterval;
            }

            /// <inheritdoc/>
            public override void Visit(SetStreamTimestampMessage message)
            {
                Model.Timestamp = message.Timestamp;
            }

            #endregion

            #region Private Impl.

            private FeedModel Model { get; set; }

            #endregion
        }
    }
}