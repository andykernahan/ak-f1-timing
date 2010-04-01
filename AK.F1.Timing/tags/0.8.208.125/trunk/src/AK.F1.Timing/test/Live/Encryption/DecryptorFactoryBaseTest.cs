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
using Moq;
using Xunit;

namespace AK.F1.Timing.Live.Encryption
{
    public class DecryptorFactoryBaseTest
    {
        [Fact]
        public void can_create_default_decryptor() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.Create());
        }

        [Fact]
        public void the_default_decryptor_is_created_with_the_default_seed() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.Create());
            Assert.Equal(DecryptorFactoryBase.DefaultSeed, factory.CreateWithSeed_Seed);
        }

        [Fact]
        public void seed_returned_by_get_seed_for_session_is_used_to_create_the_decryptor() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.Create("sessionId"));
            Assert.Equal(7, factory.CreateWithSeed_Seed);
        }

        [Fact]
        public void seeds_for_previously_resolved_sessions_are_cached() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.Create("sessionId"));
            Assert.Equal(1, factory.GetSeedForSessionCount);
            Assert.NotNull(factory.Create("sessionId"));
            Assert.Equal(1, factory.GetSeedForSessionCount);
        }

        [Fact]
        public void the_seed_cache_is_case_sensitive() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.Create("sessionId"));
            Assert.Equal(1, factory.GetSeedForSessionCount);
            Assert.NotNull(factory.Create("SessionId"));
            Assert.Equal(2, factory.GetSeedForSessionCount);
        }

        [Fact]
        public void can_get_the_factory_log() {

            var factory = new StubDecryptorFactory();

            Assert.NotNull(factory.GetLogProperty());
        }

        private sealed class StubDecryptorFactory : DecryptorFactoryBase
        {
            protected override int GetSeedForSession(string sessionId) {

                ++this.GetSeedForSessionCount;

                return 7;
            }

            public int GetSeedForSessionCount { get; set; }

            protected override IDecryptor CreateWithSeed(int seed) {

                this.CreateWithSeed_Seed = seed;

                return new Mock<IDecryptor>().Object;
            }

            public log4net.ILog GetLogProperty() {

                return this.Log;
            }

            public int CreateWithSeed_Seed { get; set; }
        }
    }
}
