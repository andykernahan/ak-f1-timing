// Copyright 2009 Andy Kernahan
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
using Xunit;

namespace AK.F1.Timing.Messages.Session
{
    public class RawSpeedCaptureMessageTest : MessageTestBase<RawSpeedCaptureMessage>
    {
        [Fact]
        public override void can_create()
        {
            var message = CreateMessage();

            Assert.Equal(SpeedCaptureLocation.S1, message.Location);
            Assert.Equal("VET\r123\r", message.Speeds);
        }

        [Fact]
        public void ctor_throws_if_speeds_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new RawSpeedCaptureMessage(SpeedCaptureLocation.S1, null));
        }

        [Fact]
        public void ctor_throws_if_speeds_is_empty()
        {
            Assert.Throws<ArgumentException>(() => new RawSpeedCaptureMessage(SpeedCaptureLocation.S1, string.Empty));
        }

        [Fact]
        public override void can_visit()
        {
            var message = CreateMessage();
            var visitor = CreateMockMessageVisitor();

            visitor.Setup(x => x.Visit(message));
            message.Accept(visitor.Object);
            visitor.VerifyAll();
        }

        protected override RawSpeedCaptureMessage CreateMessage()
        {
            return new RawSpeedCaptureMessage(SpeedCaptureLocation.S1, "VET\r123\r");
        }
    }
}