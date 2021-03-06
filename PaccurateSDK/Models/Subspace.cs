﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    /// <summary>
    /// Represents a sub space within a boxed item
    /// </summary>
    [Serializable]
    [DataContract]
    public class Subspace : IEquatable<Subspace>, IValidatableObject
    {

        public Subspace()
        {

        }

        /// <summary>
        /// the coordinates of the origin of the current subspace translated into its immediate parent.
        /// </summary>
        [DataMember(Name = "originInParent", EmitDefaultValue = false)]
        public Point OriginInParent { get; set; }

        /// <summary>
        /// the index (Box.id) of the subspace’s parent box.
        /// </summary>
        [DataMember(Name = "parentBoxIndex", EmitDefaultValue = false)]
        public int? ParentBoxIndex { get; set; }

        /// <summary>
        /// the index (Item.index) of the subspace’s parent item, if applicable.
        /// </summary>
        [DataMember(Name = "parentItemIndex", EmitDefaultValue = false)]
        public int? ParentItemIndex { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Subspace {\n");
            sb.Append("  OriginInParent: ").Append(OriginInParent).Append("\n");
            sb.Append("  ParentBoxIndex: ").Append(ParentBoxIndex).Append("\n");
            sb.Append("  ParentItemIndex: ").Append(ParentItemIndex).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Subspace);
        }

        /// <summary>
        /// Returns true if Subspace instances are equal
        /// </summary>
        /// <param name="input">Instance of Subspace to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Subspace input)
        {
            if (input == null)
                return false;

            return
                (
                    this.OriginInParent == input.OriginInParent ||
                    (this.OriginInParent != null &&
                    this.OriginInParent.Equals(input.OriginInParent))
                ) &&
                (
                    this.ParentBoxIndex == input.ParentBoxIndex ||
                    (this.ParentBoxIndex != null &&
                    this.ParentBoxIndex.Equals(input.ParentBoxIndex))
                ) &&
                (
                    this.ParentItemIndex == input.ParentItemIndex ||
                    (this.ParentItemIndex != null &&
                    this.ParentItemIndex.Equals(input.ParentItemIndex))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.OriginInParent != null)
                    hashCode = hashCode * 59 + this.OriginInParent.GetHashCode();
                if (this.ParentBoxIndex != null)
                    hashCode = hashCode * 59 + this.ParentBoxIndex.GetHashCode();
                if (this.ParentItemIndex != null)
                    hashCode = hashCode * 59 + this.ParentItemIndex.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
