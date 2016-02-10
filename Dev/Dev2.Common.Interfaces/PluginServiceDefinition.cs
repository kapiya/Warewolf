﻿
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using Dev2.Common.Interfaces.DB;

namespace Dev2.Common.Interfaces
{
    public class PluginServiceDefinition : IPluginService, IEquatable<PluginServiceDefinition>
    {
        #region Implementation of IPluginService

        public string Name { get; set; }
        public Guid Id { get; set; }
        public IPluginSource Source { get; set; }
        public IList<IServiceInput> Inputs { get; set; }
        public IList<IServiceOutputMapping> OutputMappings { get; set; }
        public string Path { get; set; }
        public IPluginAction Action { get; set; }

        #endregion

        #region Implementation of IEquatable<IPluginService>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IPluginService other)
        {
            return Equals(other as PluginServiceDefinition);
        }

        #endregion

        #region Equality members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(PluginServiceDefinition other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return string.Equals(Name, other.Name) && Id.Equals(other.Id) && Equals(Source, other.Source) && string.Equals(Path, other.Path) && Equals(Action, other.Action);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((PluginServiceDefinition)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Action != null ? Action.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(PluginServiceDefinition left, PluginServiceDefinition right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PluginServiceDefinition left, PluginServiceDefinition right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
