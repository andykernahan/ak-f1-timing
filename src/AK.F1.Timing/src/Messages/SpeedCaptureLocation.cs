﻿// Copyright 2011 Andy Kernahan
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

namespace AK.F1.Timing.Messages
{
    /// <summary>
    /// Specifies the location of a speed capture.
    /// </summary>
    [Serializable]
    public enum SpeedCaptureLocation
    {
        /// <summary>
        /// Sector one.
        /// </summary>
        S1,
        /// <summary>
        /// Sector two.
        /// </summary>
        S2,
        /// <summary>
        /// Sector three.
        /// </summary>
        S3,
        /// <summary>
        /// Straight.
        /// </summary>
        Straight
    }
}