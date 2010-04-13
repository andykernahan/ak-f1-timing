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

namespace AK.F1.Timing.Messages.Weather
{
    public class SetWindAngleMessageTest : MessageTestBase<SetWindAngleMessage>
    {
        [Fact]
        public override void can_create() {

            var message = CreateMessage();

            Assert.Equal(1, message.Angle);
        }

        [Fact]
        public override void can_visit() {

            var message = CreateMessage();
            var visitor = CreateMockMessageVisitor();

            visitor.Setup(x => x.Visit(message));
            message.Accept(visitor.Object);
            visitor.VerifyAll();
        }

        [Fact]
        public void ctor_throws_if_angle_is_negative_or_greater_than_360() {

            Assert.DoesNotThrow(() => {
                new SetWindAngleMessage(0);
            });
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new SetWindAngleMessage(-1);
            });
            Assert.Throws<ArgumentOutOfRangeException>(() => {
                new SetWindAngleMessage(361);
            });
        }

        [Fact]
        public void can_validiate_a_wind_angle() {

            Assert.False(SetWindAngleMessage.IsValidAngle(-1));
            for(int i = 0; i <= 360; ++i) {
                Assert.True(SetWindAngleMessage.IsValidAngle(i));
            }
            Assert.False(SetWindAngleMessage.IsValidAngle(361));
        }

        protected override SetWindAngleMessage CreateMessage() {

            return new SetWindAngleMessage(1);
        } 
    }
}
