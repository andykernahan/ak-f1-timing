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
    public class SetRaceLapNumberMessageTest : MessageTestBase<SetRaceLapNumberMessage>
    {
        [Fact]
        public override void can_visit()
        {
            var message = CreateTestMessage();
            var visitor = CreateMockMessageVisitor();

            visitor.Setup(x => x.Visit(message));
            message.Accept(visitor.Object);
            visitor.VerifyAll();
        }

        [Fact]
        public void ctor_throws_if_lap_number_if_negative()
        {
            Assert.DoesNotThrow(() => { new SetRaceLapNumberMessage(0); });
            Assert.Throws<ArgumentOutOfRangeException>(() => { new SetRaceLapNumberMessage(-1); });
        }

        protected override void AssertEqualsTestMessage(SetRaceLapNumberMessage message)
        {
            Assert.Equal(1, message.LapNumber);
        }

        protected override SetRaceLapNumberMessage CreateTestMessage()
        {
            return new SetRaceLapNumberMessage(1);
        }
    }
}