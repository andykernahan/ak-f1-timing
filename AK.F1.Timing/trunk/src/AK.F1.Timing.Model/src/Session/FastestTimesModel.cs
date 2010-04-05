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

using AK.F1.Timing.Model.Driver;

namespace AK.F1.Timing.Model.Session
{
    /// <summary>
    /// Contains information relating to the fastest times set during a session.
    /// </summary>
    [Serializable]
    public class FastestTimesModel : ModelBase
    {
        #region Private Fields.

        private FastestTimeModel _lap;
        private FastestTimeModel _s1;
        private FastestTimeModel _s2;
        private FastestTimeModel _s3;
        private FastestTimeModel _possible;        

        #endregion

        #region Public Interface.

        /// <summary>
        /// Resets this model.
        /// </summary>
        public void Reset() {

            this.Lap = null;
            this.S1 = null;
            this.S2 = null;
            this.S3 = null;
            this.Possible = null;
        }

        /// <summary>
        /// Sets the new fastest sector time for the one-based specified sector number.
        /// </summary>
        /// <param name="sectorNumber">The one-based sector time to set.</param>
        /// <param name="time">The time.</param>        
        /// <param name="driver">The driver which posted the time.</param>
        /// <param name="lapNumber">The lap number on which the time was set.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throw when <paramref name="driver"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="sectorNumber"/> is less than one or greater than three.
        /// </exception>
        public void SetSector(int sectorNumber, TimeSpan time, DriverModel driver, int lapNumber) {

            Guard.NotNull(driver, "driver");

            if(sectorNumber == 1) {
                this.S1 = CreateFastestTime(time, driver, lapNumber, this.S1);
            } else if(sectorNumber == 2) {
                this.S2 = CreateFastestTime(time, driver, lapNumber, this.S2);
            } else if(sectorNumber == 3) {
                this.S3 = CreateFastestTime(time, driver, lapNumber, this.S3);
            } else {
                throw Guard.ArgumentOutOfRange("sectorNumber");
            }
        }

        /// <summary>
        /// Sets the new fastest lap time.
        /// </summary>
        /// <param name="time">The time.</param>        
        /// <param name="driver">The driver which posted the time.</param>
        /// <param name="lapNumber">The lap number on which the time was set.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throw when <paramref name="driver"/> is <see langword="null"/>.
        /// </exception>
        public void SetLap(TimeSpan time, DriverModel driver, int lapNumber) {

            Guard.NotNull(driver, "driver");

            this.Lap = CreateFastestTime(time, driver, lapNumber, this.Lap);
        }

        /// <summary>
        /// Gets the fastest lap time set.
        /// </summary>
        public FastestTimeModel Lap {

            get { return _lap; }
            private set {
                if(SetProperty("Lap", ref _lap, value)) {                    
                    ComputePossible();
                    NotifyIsEmptyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the fastest S1 time set.
        /// </summary>
        public FastestTimeModel S1 {

            get { return _s1; }
            private set {
                if(SetProperty("S1", ref _s1, value)) {
                    ComputePossible();
                    NotifyIsEmptyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the fastest S2 time set.
        /// </summary>
        public FastestTimeModel S2 {

            get { return _s2; }
            private set {
                if(SetProperty("S2", ref _s2, value)) {                    
                    ComputePossible();
                    NotifyIsEmptyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the fastest S3 time set.
        /// </summary>
        public FastestTimeModel S3 {

            get { return _s3; }
            private set {
                if(SetProperty("S3", ref _s3, value)) {                    
                    ComputePossible();
                    NotifyIsEmptyChanged();
                }
            }
        }

        /// <summary>
        /// Gets the fastest possible lap given the S1-S3 times. In this case the
        /// <see cref="FastestTimeModel.Delta"/> property represents the difference between the sum
        /// of the S1-S3 times and the the current fastest lap.
        /// </summary>
        public FastestTimeModel Possible {

            get { return _possible; }
            private set { SetProperty("Possible", ref _possible, value); }
        }

        /// <summary>
        /// Gets a value indicating if this model is empty.
        /// </summary>
        public bool IsEmpty {

            get {
                // Possible is not included as it's computed base on S1-S3 and Lap.
                return this.S1 == null && this.S2 == null && this.S3 == null && this.Lap == null;
            }
        }

        #endregion

        #region Private Impl.

        private static FastestTimeModel CreateFastestTime(TimeSpan time, DriverModel driver,
            int lapNumber, FastestTimeModel previous) {

            return new FastestTimeModel(time,
                previous != null ? new Nullable<TimeSpan>(time - previous.Time) : null,
                driver, lapNumber);
        }

        private void ComputePossible() {

            if(this.S1 == null || this.S2 == null || this.S3 == null) {
                this.Possible = null;                
            } else {
                var newPossibleTime = this.S1.Time + this.S2.Time + this.S3.Time;
                // TODO this is a bit hackish. Need a better was of expressing this.
                this.Possible = new FastestTimeModel(newPossibleTime,
                    ComputeDiffFromLap(newPossibleTime), null, 0);
            }            
        }

        private TimeSpan? ComputeDiffFromLap(TimeSpan value) {

            if(this.Lap == null) {
                return null;
            }

            return this.Lap.Time - value;
        }

        private void NotifyIsEmptyChanged() {

            OnPropertyChanged("IsEmpty");
        }

        #endregion
    }
}
