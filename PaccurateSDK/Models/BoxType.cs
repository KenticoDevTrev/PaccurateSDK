using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    [Serializable]
    [DataContract]
    public class BoxType : BoxProperties, IEquatable<BoxType>, IValidatableObject
    {
        /// <summary>
        /// Blank Constructor, for deserialization
        /// </summary>
        [JsonConstructor]
        public BoxType() : base()
        {

        }

        /// <summary>
        /// Constructor with required fields
        /// </summary>
        /// <param name="WeightMax">Max Weight of the box</param>
        /// <param name="Dimensions">The box dimensions</param>
        public BoxType(decimal WeightMax, Point Dimensions) : base(WeightMax, Dimensions)
        {
            
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BoxType {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
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
            return this.Equals(input as BoxType);
        }

        /// <summary>
        /// Returns true if BoxType instances are equal
        /// </summary>
        /// <param name="input">Instance of BoxType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BoxType input)
        {
            if (input == null)
                return false;

            return base.Equals(input);
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
            // Price (decimal?) minimum
            if (this.Price < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Price, must be a value greater than or equal to 0.", new[] { "Price" });
            }

            // WeightTare (decimal?) minimum
            if (this.WeightTare < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightTare, must be a value greater than or equal to 0.", new[] { "WeightTare" });
            }

            // WeightMax (decimal?) minimum
            if (this.WeightMax < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightMax, must be a value greater than or equal to 0.", new[] { "WeightMax" });
            }

            yield break;
        }
    }
}
