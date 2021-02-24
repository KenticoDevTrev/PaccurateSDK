using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    /// <summary>
    /// set of items sharing a common type.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ItemSet : ItemProperties, IEquatable<ItemSet>, IValidatableObject
    {
        /// <summary>
        /// Blank Constructor, for deserialization
        /// </summary>
        [JsonConstructor]
        public ItemSet()
        {
        }

        /// <summary>
        /// Constructor with required fields
        /// </summary>
        /// <param name="WeightMax">Max Weight of the box</param>
        /// <param name="Dimensions">The box dimensions</param>
        /// <param name="Quantity">Number of Items</param>
        public ItemSet(decimal Weight, Point Dimensions, int Quantity = 1) : base(Weight, Dimensions)
        {
            this.Quantity = Quantity;
        }

        /// <summary>
        /// quantity of items of this type in this item set
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public int? Quantity { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemSet {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as ItemSet);
        }

        /// <summary>
        /// Returns true if ItemSet instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemSet to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemSet input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
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
                int hashCode = base.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}