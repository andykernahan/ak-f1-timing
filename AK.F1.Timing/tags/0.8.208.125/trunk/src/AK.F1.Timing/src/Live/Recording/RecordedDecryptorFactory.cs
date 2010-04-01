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
using System.IO;

using AK.F1.Timing.Live.Encryption;

namespace AK.F1.Timing.Live.Recording
{
    /// <summary>
    /// An <see cref="AK.F1.Timing.Live.Encryption.IDecryptorFactory"/> implementation
    /// that creates decryptors with seeds that have been persisted on the file system. This
    /// class cannot be inherited.
    /// </summary>
    public sealed class RecordedDecryptorFactory : DecryptorFactoryBase
    {
        #region Private Fields.
        
        private static readonly CultureInfo INV_CULTURE = CultureInfo.InvariantCulture;

        #endregion

        #region Interval Fields.

        internal const string FILE_EXT = ".seed";

        #endregion

        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="RecordedDecryptorFactory"/> class and
        /// specifies the directory which contains the persisted seeds.
        /// </summary>
        /// <param name="directory">The directory which contains the persisted seeds.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="directory"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">
        /// Thrown when <paramref name="directory"/> does not exist.
        /// </exception>
        public RecordedDecryptorFactory(string directory) {

            Guard.NotNull(directory, "directory");
            Guard.DirectoryExists(directory, "directory");

            this.Directory = directory;
        }

        #endregion

        #region Protected Interface.

        /// <inheritdoc />
        protected override int GetSeedForSession(string sessionId) {

            Guard.NotNullOrEmpty(sessionId, "sessionId");

            int seed;
            string seedPath = BuildSeedPath(sessionId);

            this.Log.InfoFormat("opening: {0}", seedPath);
            seed = (int)(long.Parse(File.ReadAllText(seedPath), NumberStyles.HexNumber, INV_CULTURE) & 0xFFFFFFFF);
            this.Log.InfoFormat("opened, seed: {0}", seed);

            return seed;
        }

        /// <inheritdoc />
        protected override IDecryptor CreateWithSeed(int seed) {

            return new LiveDecryptor(seed);
        }

        #endregion

        #region Private Impl.

        private string BuildSeedPath(string sessionId) {

            return Path.Combine(this.Directory, sessionId + FILE_EXT);
        }       

        private string Directory { get; set; }

        #endregion
    }
}
