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
using System.Runtime.Serialization;

using AK.F1.Timing.Extensions;
using AK.F1.Timing.Utility;

namespace AK.F1.Timing.Serialization
{
    /// <summary>
    /// Provides <see cref="System.Reflection.PropertyInfo"/> information required during
    /// serialization and deserialization by the <see cref="DecoratedObjectWriter"/> and
    /// <see cref="DecoratedObjectReader"/> respectively. This class cannot be inherited.
    /// </summary>
    [Serializable]
    public sealed class PropertyDescriptor : IEquatable<PropertyDescriptor>
    {
        #region Public Interface.

        /// <summary>
        /// Returns the <see cref="PropertyDescriptor"/> for the specified
        /// <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>The <see cref="PropertyDescriptor"/> for the specified
        /// <paramref name="property"/>.</returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// Thrown when the specified <paramref name="property"/> has not been decorated with the
        /// <see cref="PropertyIdAttribute"/> or it does not define a getter and setter.
        /// </exception>
        public static PropertyDescriptor For(PropertyInfo property) {

            Guard.NotNull(property, "property");

            int propertyId = GetPropertyId(property);
            var typeDescriptor = TypeDescriptor.For(property.DeclaringType);

            return typeDescriptor.Properties.GetById(propertyId);
        }

        /// <summary>
        /// Returns the value of the property given the specified <paramref name="component"/>.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>The value of the property given the specified
        /// <paramref name="component"/>.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="component"/> is <see langword="null"/>.
        /// </exception>
        public object GetValue(object component) {

            Guard.NotNull(component, "component");            

            return this.Property.GetGetMethod().Invoke(component, null);
        }

        /// <summary>
        /// Sets this property to the given <paramref name="value"/> on the given
        /// <paramref name="component"/>.
        /// </summary>        
        /// <param name="component">The component.</param>
        /// <param name="value">The value.</param>        
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when <paramref name="component"/> is <see langword="null"/>.
        /// </exception>
        public void SetValue(object component, object value) {

            Guard.NotNull(component, "component");

            this.Property.GetSetMethod(true).Invoke(component, new[] { value });
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) {

            if(obj == null || obj.GetType() != GetType()) {
                return false;
            }
            return Equals((PropertyDescriptor)obj);
        }

        /// <inheritdoc/>
        public bool Equals(PropertyDescriptor other) {

            return other != null &&
                other.PropertyId == this.PropertyId &&
                other.Property.DeclaringType.Equals(this.Property.DeclaringType);
        }

        /// <inheritdoc/>
        public override int GetHashCode() {

            return HashCodeBuilder.New()
                .Add(this.PropertyId)
                .Add(this.Property.DeclaringType);
        }

        /// <inheritdoc/>
        public override string ToString() {

            return this.Property.ToString();
        }

        /// <summary>
        /// Gets the underlying <see cref="System.Reflection.PropertyInfo"/> which provides
        /// information about the property.
        /// </summary>
        public PropertyInfo Property { get; private set; }

        /// <summary>
        /// Gets the property identifier.
        /// </summary>
        public byte PropertyId { get; private set; }

        #endregion

        #region Internal Interface.

        /// <summary>
        /// Creates a <see cref="PropertyDescriptor"/> for the specified
        /// <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>The <see cref="PropertyDescriptor"/> for the specified
        /// <paramref name="property"/>.</returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">
        /// Thrown when the specified <paramref name="property"/> has not been decorated with the
        /// <see cref="PropertyIdAttribute"/> or it does not define a getter and setter.
        /// </exception>
        internal static PropertyDescriptor Create(PropertyInfo property) {

            byte propertyId = GetPropertyId(property);

            CheckHasGetAndSetMethod(property);

            return new PropertyDescriptor(property, propertyId);
        }

        #endregion

        #region Private Impl.

        private PropertyDescriptor(PropertyInfo property, byte propertyId) {

            this.Property = property;
            this.PropertyId = propertyId;
        }

        private static void CheckHasGetAndSetMethod(PropertyInfo property) {

            if(!(property.CanRead && property.CanWrite)) {
                throw Guard.PropertyDescriptor_PropertyHaveGetAndSetMethod(property);
            }            
        }

        private static byte GetPropertyId(PropertyInfo property) {

            PropertyIdAttribute attribute = property.GetAttribute<PropertyIdAttribute>();

            if(attribute == null) {
                throw Guard.PropertyDescriptor_PropertyIsNotDecorated(property);                
            }

            return attribute.Id;
        }

        #endregion
    }
}