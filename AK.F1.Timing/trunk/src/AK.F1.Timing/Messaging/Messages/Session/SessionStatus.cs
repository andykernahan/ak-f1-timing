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
using AK.F1.Timing.Messaging.Serialization;

namespace AK.F1.Timing.Messaging.Messages.Session
{
    /// <summary>
    /// Defines the various statuses of an F1 live timing session.
    /// </summary>
    [Serializable]
    [TypeId(88544499)]
    public enum SessionStatus
    {
        /// <summary>
        /// The race is running with no current incident.
        /// </summary>
        Green,
        /// <summary>
        /// There is an incident somewhere on the circuit. Yellow flags are being used to warn
        /// the drivers.
        /// </summary>
        Yellow,
        /// <summary>
        /// Yellow flags are out following an incident and the safety car is on standby.
        /// </summary>
        SafetyCarOnStandBy,
        /// <summary>
        /// Yellow flags and the safety car has been deployed due to a serious incident.
        /// </summary>
        SafetyCarDeployed,
        /// <summary>
        /// The practice this has been aborted or the race suspended due to a serious incident.
        /// </summary>
        Red
    }
}
