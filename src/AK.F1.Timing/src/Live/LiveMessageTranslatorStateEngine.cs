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
using AK.F1.Timing.Messages.Driver;
using AK.F1.Timing.Messages.Session;

namespace AK.F1.Timing.Live
{
    /// <summary>
    /// An engine which updates the state information maintained by a
    /// <see cref="LiveMessageTranslator"/>. This class cannot be inherited.
    /// </summary>
    [Serializable]
    internal sealed class LiveMessageTranslatorStateEngine : MessageVisitorBase, IMessageProcessor
    {
        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="LiveMessageTranslatorStateEngine"/> class
        /// and specified the <paramref name="translator"/> to update.
        /// </summary>
        /// <param name="translator">The translator to update.</param>
        public LiveMessageTranslatorStateEngine(LiveMessageTranslator translator)
        {
            Translator = translator;
        }

        /// <inheritdoc/>
        public void Process(Message message)
        {
            message.Accept(this);
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverStatusMessage message)
        {
            GetDriver(message).ChangeStatus(message.DriverStatus);
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverPositionMessage message)
        {
            GetDriver(message).Position = message.Position;
        }

        public override void Visit(SetDriverSectorTimeMessage message)
        {
            LiveDriver driver = GetDriver(message);

            driver.SetLastSector(message.SectorNumber, message.SectorTime);
            driver.CurrentSectorNumber = message.SectorNumber != 3 ? message.SectorNumber + 1 : 1;
        }

        /// <inheritdoc/>
        public override void Visit(ReplaceDriverSectorTimeMessage message)
        {
            GetDriver(message).SetLastSector(message.SectorNumber, message.Replacement);
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverLapTimeMessage message)
        {
            GetDriver(message).LastLapTime = message.LapTime;
        }

        /// <inheritdoc/>
        public override void Visit(ReplaceDriverLapTimeMessage message)
        {
            GetDriver(message).LastLapTime = message.Replacement;
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverPitCountMessage message)
        {
            if(Translator.IsRaceSession)
            {
                LiveDriver driver = GetDriver(message);
                // We only expect pit times when the driver is pitted.
                driver.IsExpectingPitTimes = driver.IsInPits;
            }
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverPitTimeMessage message)
        {
            GetDriver(message).IsExpectingPitTimes = false;
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverGapMessage message)
        {
            GetDriver(message).LastGapMessage = message;
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverIntervalMessage message)
        {
            GetDriver(message).LastIntervalMessage = message;
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverCarNumberMessage message)
        {
            GetDriver(message).CarNumber = message.CarNumber;
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverNameMessage message)
        {
            GetDriver(message).Name = message.DriverName;
        }

        /// <inheritdoc/>
        public override void Visit(SetSessionTypeMessage message)
        {
            Translator.ChangeSessionType(message.SessionType);
        }

        /// <inheritdoc/>
        public override void Visit(SetRaceLapNumberMessage message)
        {
            Translator.RaceLapNumber = message.LapNumber;
        }

        /// <inheritdoc/>
        public override void Visit(SetGridColumnValueMessage message)
        {
            GetDriver(message).SetColumnHasValue(message.Column, !message.ClearColumn);
        }

        /// <inheritdoc/>
        public override void Visit(SetDriverLapNumberMessage message)
        {
            GetDriver(message).LapNumber = message.LapNumber;
        }

        #endregion

        #region Private Impl.

        private LiveDriver GetDriver(DriverMessageBase message)
        {
            return Translator.GetDriver(message);
        }

        private LiveMessageTranslator Translator { get; set; }

        #endregion
    }
}