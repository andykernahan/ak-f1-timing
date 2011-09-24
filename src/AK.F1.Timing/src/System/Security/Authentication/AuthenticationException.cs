// Copyright 2011 Andy Kernahan
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

namespace System.Security.Authentication
{
    /// <summary>
    /// The exception that is thrown when authentication fails for an authentication stream.
    /// </summary>
    public class AuthenticationException : Exception
    {
        #region Public Interface.

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="System.Security.Authentication.AuthenticationException"/> class with the
        /// specified message.
        /// </summary>
        /// <param name="message">A <see cref="System.String"/> that describes the authentication
        /// failure.</param>
        public AuthenticationException(string message) : base(message) { }

        #endregion
    }
}