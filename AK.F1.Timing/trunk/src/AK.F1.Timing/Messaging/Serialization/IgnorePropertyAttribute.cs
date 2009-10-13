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
using System.Reflection;

namespace AK.F1.Timing.Messaging.Serialization
{
    /// <summary>
    /// Specifies that the decorated property should not be serialized. This class is
    /// <see langword="sealed"/>.
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class IgnorePropertyAttribute : Attribute
    {
        #region Public Interface.

        /// <summary>
        /// Initialises a new instance of the <see cref="IgnorePropertyAttribute"/> class.
        /// </summary>
        public IgnorePropertyAttribute() { }

        /// <summary>
        /// Returns a value indicating if the <see cref="IgnorePropertyAttribute"/> is applied to the
        /// specified <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns><see langword="true"/> if the attribute is applied to the specified property,
        /// otherwise; <see langword="false"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="property"/> is <see langword="null"/>.
        /// </exception>
        public static bool IsDefined(PropertyInfo property) {

            Guard.NotNull(property, "property");

            return Attribute.IsDefined(property, typeof(IgnorePropertyAttribute), false);
        }

        #endregion
    }
}