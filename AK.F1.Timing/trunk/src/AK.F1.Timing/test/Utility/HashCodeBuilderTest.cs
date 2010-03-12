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
using System.Linq;
using Xunit;

using AK.F1.Timing.Utility;

namespace AK.F1.Timing.Utility
{
    public class HashCodeBuilderTest
    {
        [Fact]
        public void builder_should_use_algorithm_detailed_in_effective_java() {

            int expected = 7;
            var builder = HashCodeBuilder.New();

            for(int i = 0; i < 10; ++i) {
                Assert.Equal(expected, builder.GetHashCode());
                expected = 31 * expected + i.GetHashCode();
                builder.Add(i);                
            }            
        }

        [Fact]
        public void equals_returns_true_for_equal_instances() {

            var a = HashCodeBuilder.New().Add(0).Add(1);
            var b = HashCodeBuilder.New().Add(0).Add(1);

            Assert.True(a.Equals(a));
            Assert.True(a.Equals((object)a));            

            Assert.True(a.Equals(b));
            Assert.True(a.Equals((object)b));

            Assert.True(b.Equals(a));
            Assert.True(b.Equals((object)a));
        }

        [Fact]
        public void equals_returns_false_for_unequal_instances() {

            var a = HashCodeBuilder.New();
            var b = HashCodeBuilder.New().Add(0).Add(1);

            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)b));

            Assert.False(a.Equals(null));

            // This is not complete, but how do you test against every type?!
            Assert.False(a.Equals(string.Empty));
            Assert.False(a.Equals(new object()));
        }

        [Fact]
        public void to_string_returns_string_representation_of_hashcode() {

            var builder = HashCodeBuilder.New().Add(0).Add(1);

            Assert.Equal(builder.GetHashCode().ToString(), builder.ToString());
        }

        [Fact]
        public void add_should_accept_null_and_not_alter_the_hashcode() {

            var builder = HashCodeBuilder.New();
            int hash = builder.GetHashCode();

            Assert.DoesNotThrow(() => builder.Add<object>(null));
            Assert.Equal(hash, builder.GetHashCode());
        }

        [Fact]
        public void explicit_int32_conversion_operator_returns_hashcode() {

            var builder = HashCodeBuilder.New().Add(1).Add(2);
            
            Assert.Equal(builder.GetHashCode(), builder);
        }
    }
}
