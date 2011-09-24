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

namespace log4net
{
    /// <summary>
    /// A drop in replacement for <see cref="log4net.ILog"/>.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(object message);

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="format">The format specification.</param>
        /// <param name="args">The format arguments.</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(object message);

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="format">The format specification.</param>
        /// <param name="args">The format arguments.</param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(object message);

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="format">The format specification.</param>
        /// <param name="args">The format arguments.</param>
        void ErrorFormat(string format, params object[] args);
    }
}