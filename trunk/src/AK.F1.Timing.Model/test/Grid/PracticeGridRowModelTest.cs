﻿// Copyright 2010 Andy Kernahan
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
using System.Collections.Generic;

using AK.F1.Timing.Messages.Driver;

namespace AK.F1.Timing.Model.Grid
{
    public class PracticeGridRowModelTest : GridRowModelTestBase<PracticeGridRowModel>
    {
        protected override PracticeGridRowModel CreateRow(int driverId) {

            return new PracticeGridRowModel(driverId);
        }

        protected override IEnumerable<GridColumn> GetColumns() {

            yield return GridColumn.LapTime;
            yield return GridColumn.Gap;
            yield return GridColumn.Laps;
            yield return GridColumn.Unknown;
        }

        protected override IEnumerable<GridColumn> GetResettableColumns() {

            return GetColumns();
        }
    }
}