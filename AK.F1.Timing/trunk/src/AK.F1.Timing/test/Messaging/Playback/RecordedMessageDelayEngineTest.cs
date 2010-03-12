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
using System.Collections.Generic;
using Xunit;

using AK.F1.Timing;
using AK.F1.Timing.Recording;

namespace AK.F1.Timing.Test.Messaging.Recording
{
    public class RecordedMessageDelayEngineTest
    {
        [Fact]
        public void ctor_throws_if_reader_is_null() {

            Assert.Throws<ArgumentNullException>(() => {
                var engine = new RecordedMessageDelayEngine(null);
            });
        }

        [Fact]
        public void engine_should_delay_by_amount_specified_in_message() {

            
        }


    }
}