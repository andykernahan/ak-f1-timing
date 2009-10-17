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
using System.Windows;

namespace AK.F1.Timing.UI.Views
{
    /// <summary>
    /// The main view window.
    /// </summary>
    public partial class MainView : Window
    {
        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView() {

            InitializeComponent();                        
        }

        #endregion

        #region Private Impl.

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {

            Size size = e.NewSize;

            if(this.MinHeight < size.Height) {
                this.MinHeight = size.Height;                
            }
            if(this.MinWidth < size.Width) {
                this.MinWidth = size.Width;
            }
        }

        #endregion
    }
}
