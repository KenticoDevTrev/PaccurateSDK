using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    [Serializable]
    [DataContract]
    public class ItemProperties : IEquatable<ItemProperties>, IValidatableObject
    {
        [JsonConstructor]
        public ItemProperties() {

        }

        public ItemProperties(decimal? Weight, Point Dimensions)
        {
            // to ensure "weight" is required (not null)
            if (Weight == null)
            {
                throw new InvalidDataException("weight is a required property for ItemProperties and cannot be null");
            }
            else
            {
                this.Weight = Weight;
            }
            // to ensure "dimensions" is required (not null)
            if (Dimensions == null)
            {
                throw new InvalidDataException("dimensions is a required property for ItemProperties and cannot be null");
            }
            else
            {
                this.Dimensions = Dimensions;
            }
        }

        /// <summary>
        /// item type reference identifier passed backed from request.
        /// </summary>
        [DataMember(Name = "refId", EmitDefaultValue = false)]
        public int? RefId { get; set; }

        /// <summary>
        /// name or description of item for your reference.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// designated color name (css color name) for the item in pack visualizations.
        /// </summary>
        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string Color { get; set; }

        /// <summary>
        /// weight of this single packed item.
        /// </summary>
        [DataMember(Name = "weight", EmitDefaultValue = false)]
        public decimal? Weight { get; set; }

        /// <summary>
        /// A sequence value for the item. This is intended for aisle-bin locations, e.g., aisle 11 bin 20 can be '1120’. Combined with maxSequenceDistance, you can restrict cartons to only have contents from within a certain range. This is very helpful for cartonization when picking efficiency is paramount. Sequence can also be used to pre-sort items for efficient packing on any arbitrary number, such as item weight instead of the default item volume.
        /// </summary>
        [DataMember(Name = "sequence", EmitDefaultValue = false)]
        public string Sequence { get; set; }

        /// <summary>
        /// the [height,length,width] of the item.
        /// </summary>
        [DataMember(Name = "dimensions", EmitDefaultValue = false)]
        public Point Dimensions { get; set; }

        /// <summary>
        /// the coordinates of the center of mass of the item.
        /// </summary>
        [DataMember(Name = "centerOfMass", EmitDefaultValue = false)]
        public Point CenterOfMass { get; set; }

        /// <summary>
        /// default: false
        /// whether or not this is a real item or a virtual, blocking space(from a subspace or loading rules)
        /// </summary>
        [DataMember(Name = "virtual", EmitDefaultValue = false)]
        public bool? Virtual { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemProperties {\n");
            sb.Append("  RefId: ").Append(RefId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  Sequence: ").Append(Sequence).Append("\n");
            sb.Append("  Dimensions: ").Append(Dimensions).Append("\n");
            sb.Append("  CenterOfMass: ").Append(CenterOfMass).Append("\n");
            sb.Append("  Virtual: ").Append(Virtual).Append("\n");
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
            return this.Equals(input as ItemProperties);
        }

        /// <summary>
        /// Returns true if ItemProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of ItemProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemProperties input)
        {
            if (input == null)
                return false;

            return
                (
                    this.RefId == input.RefId ||
                    (this.RefId != null &&
                    this.RefId.Equals(input.RefId))
                ) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.Color == input.Color ||
                    (this.Color != null &&
                    this.Color.Equals(input.Color))
                ) &&
                (
                    this.Weight == input.Weight ||
                    (this.Weight != null &&
                    this.Weight.Equals(input.Weight))
                ) &&
                (
                    this.Sequence == input.Sequence ||
                    (this.Sequence != null &&
                    this.Sequence.Equals(input.Sequence))
                ) &&
                (
                    this.Dimensions == input.Dimensions ||
                    (this.Dimensions != null &&
                    this.Dimensions.Equals(input.Dimensions))
                ) &&
                (
                    this.CenterOfMass == input.CenterOfMass ||
                    (this.CenterOfMass != null &&
                    this.CenterOfMass.Equals(input.CenterOfMass))
                ) &&
                (
                    this.Virtual == input.Virtual ||
                    (this.Virtual != null &&
                    this.Virtual.Equals(input.Virtual))
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
                if (this.RefId != null)
                    hashCode = hashCode * 59 + this.RefId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Color != null)
                    hashCode = hashCode * 59 + this.Color.GetHashCode();
                if (this.Weight != null)
                    hashCode = hashCode * 59 + this.Weight.GetHashCode();
                if (this.Sequence != null)
                    hashCode = hashCode * 59 + this.Sequence.GetHashCode();
                if (this.Dimensions != null)
                    hashCode = hashCode * 59 + this.Dimensions.GetHashCode();
                if (this.CenterOfMass != null)
                    hashCode = hashCode * 59 + this.CenterOfMass.GetHashCode();
                if (this.Virtual != null)
                    hashCode = hashCode * 59 + this.Virtual.GetHashCode();
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
