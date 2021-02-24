using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    /// <summary>
    /// a specific, packed item.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Item : ItemProperties, IEquatable<Item>, IValidatableObject
    {
        /// <summary>
        /// Blank Constructor, for deserialization
        /// </summary>
        [JsonConstructor]
        public Item() : base()
        {

        }

        /// <summary>
        /// Constructor with required fields
        /// </summary>
        /// <param name="WeightMax">Max Weight of the box</param>
        /// <param name="Dimensions">The box dimensions</param>
        public Item(decimal Weight, Point Dimensions) : base(Weight, Dimensions)
        {
           
        }

        /// <summary>
        /// the sequence at which the item was packed.
        /// </summary>
        [DataMember(Name = "index", EmitDefaultValue = false)]
        public int? Index { get; set; }

        /// <summary>
        /// any relevant information or warnings about the packing of the item.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// the [x,y,z] placement point of the back-bottom corner of the item.
        /// </summary>
        [DataMember(Name = "origin", EmitDefaultValue = false)]
        public Point Origin { get; set; }

        /// <summary>
        /// the change in the estimated final cost of the box caused by adding the item.
        /// </summary>
        [DataMember(Name = "deltaCost", EmitDefaultValue = false)]
        public decimal? DeltaCost { get; set; }

        /// <summary>
        /// a combination of the item’s refId and its packing sequence, uniquely identifying it.
        /// </summary>
        [DataMember(Name = "uniqueId", EmitDefaultValue = false)]
        public string UniqueId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Item {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Index: ").Append(Index).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("  Origin: ").Append(Origin).Append("\n");
            sb.Append("  DeltaCost: ").Append(DeltaCost).Append("\n");
            sb.Append("  UniqueId: ").Append(UniqueId).Append("\n");
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
            return this.Equals(input as Item);
        }

        /// <summary>
        /// Returns true if Item instances are equal
        /// </summary>
        /// <param name="input">Instance of Item to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Item input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Index == input.Index ||
                    (this.Index != null &&
                    this.Index.Equals(input.Index))
                ) && base.Equals(input) &&
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                ) && base.Equals(input) &&
                (
                    this.Origin == input.Origin ||
                    (this.Origin != null &&
                    this.Origin.Equals(input.Origin))
                ) && base.Equals(input) &&
                (
                    this.DeltaCost == input.DeltaCost ||
                    (this.DeltaCost != null &&
                    this.DeltaCost.Equals(input.DeltaCost))
                ) && base.Equals(input) &&
                (
                    this.UniqueId == input.UniqueId ||
                    (this.UniqueId != null &&
                    this.UniqueId.Equals(input.UniqueId))
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
                if (this.Index != null)
                    hashCode = hashCode * 59 + this.Index.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                if (this.Origin != null)
                    hashCode = hashCode * 59 + this.Origin.GetHashCode();
                if (this.DeltaCost != null)
                    hashCode = hashCode * 59 + this.DeltaCost.GetHashCode();
                if (this.UniqueId != null)
                    hashCode = hashCode * 59 + this.UniqueId.GetHashCode();
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