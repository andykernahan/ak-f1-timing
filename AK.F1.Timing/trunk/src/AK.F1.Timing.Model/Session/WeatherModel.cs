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

using AK.F1.Timing.Model.Collections;
using AK.F1.Timing.Model.Driver;

namespace AK.F1.Timing.Model.Session
{
    /// <summary>
    /// Contains all information relating to the current weather condition.
    /// </summary>
    public class WeatherModel : ModelBase
    {
        #region Private Fields.

        private bool _isWet;

        #endregion

        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="WeatherModel"/> class.
        /// </summary>
        public WeatherModel() {            
            
            this.AirTemperature = new DoubleCollectionModel();
            this.TrackTemperature = new DoubleCollectionModel();
            this.Humidity = new DoubleCollectionModel();
            this.WindSpeed = new DoubleCollectionModel();
            this.Pressure = new DoubleCollectionModel();
            this.WindAngle = new DoubleCollectionModel();            
        }

        /// <summary>
        /// Resets this weather model.
        /// </summary>
        public void Reset() {
            
            this.AirTemperature.Reset();
            this.Pressure.Reset();
            this.Humidity.Reset();
            this.TrackTemperature.Reset();
            this.WindAngle.Reset();
            this.WindSpeed.Reset();
            this.IsWet = false;
        }

        /// <summary>
        /// Gets the track temperature model.
        /// </summary>
        public DoubleCollectionModel TrackTemperature { get; private set; }

        /// <summary>
        /// Gets the air temperature model.
        /// </summary>
        public DoubleCollectionModel AirTemperature { get; private set; }

        /// <summary>
        /// Gets the humidity model.
        /// </summary>
        public DoubleCollectionModel Humidity { get; private set; }

        /// <summary>
        /// Gets the atmospheric pressure model.
        /// </summary>
        public DoubleCollectionModel Pressure { get; private set; }

        /// <summary>
        /// Gets the wind speed model.
        /// </summary>
        public DoubleCollectionModel WindSpeed { get; private set; }

        /// <summary>
        /// Gets the wind angle model.
        /// </summary>
        public DoubleCollectionModel WindAngle { get; set; }

        /// <summary>
        /// Gets a value indicating if the track is wet.
        /// </summary>      
        public bool IsWet {

            get { return _isWet; }
            protected internal set { SetProperty("IsWet", ref _isWet, value); }
        }

        #endregion
    }
}
