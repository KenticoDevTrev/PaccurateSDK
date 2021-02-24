using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    /// <summary>
    /// A completed, packed box
    /// </summary>
    [Serializable]
    [DataContract]
    public class Box : BoxProperties, IEquatable<Box>, IValidatableObject
    {
        /// <summary>
        /// Blank Constructor, for deserialization
        /// </summary>
        [JsonConstructor]
        public Box() : base()
        {

        }

        /// <summary>
        /// Constructor with required fields
        /// </summary>
        /// <param name="WeightMax">Max Weight of the box</param>
        /// <param name="Dimensions">The box dimensions</param>
        public Box(decimal WeightMax, Point Dimensions) : base(WeightMax, Dimensions)
        {
            
        }

        /// <summary>
        /// The id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { get; set; }

        // Not doing subspace

        /// <summary>
        /// box types to be used for packing.
        /// </summary>
        [DataMember(Name = "boxType", EmitDefaultValue = false)]
        public BoxType BoxType { get; set; }


        /// <summary>
        /// items
        /// </summary>
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<ItemContainer> Items { get; set; }


        /// <summary>
        /// minimum: 0
        /// total volume of the box.
        /// </summary>
        [DataMember(Name = "volumeMax", EmitDefaultValue = false)]
        public decimal? VolumeMax { get; set; }

        /// <summary>
        /// minimum: 0
        /// utilized volume of the box, i.e., item volume plus reserved volume.
        /// </summary>
        [DataMember(Name = "volumeUsed", EmitDefaultValue = false)]
        public decimal? VolumeUsed { get; set; }

        /// <summary>
        /// minimum: 0
        /// volume of box utilized solely by packed items.
        /// </summary>
        [DataMember(Name = "volumeNet", EmitDefaultValue = false)]
        public decimal? VolumeNet { get; set; }

        /// <summary>
        /// minimum: 0
        /// remaining volume of the box.
        /// </summary>
        [DataMember(Name = "volumeRemaining", EmitDefaultValue = false)]
        public decimal? VolumeRemaining { get; set; }

        /// <summary>
        /// minimum: 0
        /// reserved volume of the box, i.e., void fill.
        /// </summary>
        [DataMember(Name = "volumeReserved", EmitDefaultValue = false)]
        public decimal? VolumeReserved { get; set; }

        [NonSerialized]
        private decimal? _VolumeUtilization;
       
        /// <summary>
        /// minimum: 0
        /// maximum: 1
        /// percentage of volume utilized by packed items.
        /// </summary>
        [DataMember(Name = "volumeUtilization", EmitDefaultValue = false)]
        public decimal? VolumeUtilization { get
            {
                if (!_VolumeUtilization.HasValue)
                {
                    return null;
                }
                return (_VolumeUtilization.Value < 0 ? 0 : (_VolumeUtilization.Value > 1 ? 1 : _VolumeUtilization.Value));
            } set
            {
                _VolumeUtilization = value;
            }
        }

        /// <summary>
        ///  minimum: 0
        /// utilized weight of the box.
        /// </summary>
        [DataMember(Name = "weightUsed", EmitDefaultValue = false)]
        public decimal? WeightUsed { get; set; }

        /// <summary>
        ///minimum: 0
        ///total weight of box’s contents, not including the box’s empty (tare) weight.
        /// </summary>
        [DataMember(Name = "weightNet", EmitDefaultValue = false)]
        public decimal? WeightNet { get; set; }

        /// <summary>
        /// minimum: 0
        /// remaining weight of the box.
        /// </summary>
        [DataMember(Name = "weightRemaining", EmitDefaultValue = false)]
        public decimal? WeightRemaining { get; set; }

        [NonSerialized]
        private decimal? _WeightUtilization;

        /// <summary>
        /// minimum: 0
        /// maximum: 1
        /// percentage of weight utilized by packed items.
        /// </summary>
        [DataMember(Name = "weightUtilization", EmitDefaultValue = false)]
        public decimal? WeightUtilization
        {
            get
            {
                if(!_WeightUtilization.HasValue)
                {
                    return null;
                }
                return (_WeightUtilization.Value < 0 ? 0 : (_WeightUtilization.Value > 1 ? 1 : _WeightUtilization.Value));
            } set
            {
                _WeightUtilization = value;
            }
        }

        /// <summary>
        /// the calculated dimensional weight of this box, if applicable.
        /// </summary>
        [DataMember(Name = "dimensionalWeight", EmitDefaultValue = false)]
        public decimal? DimensionalWeight { get; set; }

        /// <summary>
        /// whether or not dimensional weight was used for this box.
        /// </summary>
        [DataMember(Name = "dimensionalWeightUsed", EmitDefaultValue = false)]
        public bool? DimensionalWeightUsed { get; set; }

        /// <summary>
        /// raw svg of visualization.
        /// </summary>
        [DataMember(Name = "svg", EmitDefaultValue = false)]
        public string Svg { get; set; }

        /// <summary>
        /// string representation of box center of mass.
        /// </summary>
        [DataMember(Name = "centerOfMassString", EmitDefaultValue = false)]
        public string CenterOfMassString { get; set; }

        /// <summary>
        /// &lt;p&gt;sorted list of &#39;item.index&#39; values representing the ordering utilized by the render, back to front.&lt;/p&gt;&lt;p&gt;This list works in tandem with the &#39;eye&#39; point, and can represent a potentially feasible real-world packing order.&lt;/p&gt;&lt;p&gt;E.g., if the &#39;eye&#39; is set to &#39;{x:1, y:0, z:0}&#39;, then the packing image will show a top-down view of the carton, and &#39;depthOrder&#39; will contain the order to place items so that all items on the bottom of the carton are packed first, then those in the next layer, etc., so that no item is placed beneath another already placed item.&lt;/p&gt;&lt;p&gt;Conversely, if the &#39;eye&#39; is set to &#39;{x:0, y:0, z:1}&#39;, the packing image will show an end-on view- -as if from the doors of a shipping trailer, and &#39;depthOrder&#39; will contain the order to place items so that all items farthest from the doors are placed before items directly in front of them.&lt;/p&gt;
        /// </summary>
        /// <value>&lt;p&gt;sorted list of &#39;item.index&#39; values representing the ordering utilized by the render, back to front.&lt;/p&gt;&lt;p&gt;This list works in tandem with the &#39;eye&#39; point, and can represent a potentially feasible real-world packing order.&lt;/p&gt;&lt;p&gt;E.g., if the &#39;eye&#39; is set to &#39;{x:1, y:0, z:0}&#39;, then the packing image will show a top-down view of the carton, and &#39;depthOrder&#39; will contain the order to place items so that all items on the bottom of the carton are packed first, then those in the next layer, etc., so that no item is placed beneath another already placed item.&lt;/p&gt;&lt;p&gt;Conversely, if the &#39;eye&#39; is set to &#39;{x:0, y:0, z:1}&#39;, the packing image will show an end-on view- -as if from the doors of a shipping trailer, and &#39;depthOrder&#39; will contain the order to place items so that all items farthest from the doors are placed before items directly in front of them.&lt;/p&gt;</value>
        [DataMember(Name = "depthOrder", EmitDefaultValue = false)]
        public List<int?> DepthOrder { get; set; }


        /// <summary>
        /// string representation of depth ordering.
        /// </summary>
        [DataMember(Name = "depthOrderString", EmitDefaultValue = false)]
        public string DepthOrderString { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Box {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            //sb.Append("  Subspace: ").Append(Subspace).Append("\n");
            sb.Append("  BoxType: ").Append(BoxType).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  VolumeMax: ").Append(VolumeMax).Append("\n");
            sb.Append("  VolumeUsed: ").Append(VolumeUsed).Append("\n");
            sb.Append("  VolumeNet: ").Append(VolumeNet).Append("\n");
            sb.Append("  VolumeRemaining: ").Append(VolumeRemaining).Append("\n");
            sb.Append("  VolumeReserved: ").Append(VolumeReserved).Append("\n");
            sb.Append("  VolumeUtilization: ").Append(VolumeUtilization).Append("\n");
            sb.Append("  WeightUsed: ").Append(WeightUsed).Append("\n");
            sb.Append("  WeightNet: ").Append(WeightNet).Append("\n");
            sb.Append("  WeightRemaining: ").Append(WeightRemaining).Append("\n");
            sb.Append("  WeightUtilization: ").Append(WeightUtilization).Append("\n");
            sb.Append("  DimensionalWeight: ").Append(DimensionalWeight).Append("\n");
            sb.Append("  DimensionalWeightUsed: ").Append(DimensionalWeightUsed).Append("\n");
            sb.Append("  Svg: ").Append(Svg).Append("\n");
            sb.Append("  CenterOfMassString: ").Append(CenterOfMassString).Append("\n");
            sb.Append("  DepthOrder: ").Append(DepthOrder).Append("\n");
            sb.Append("  DepthOrderString: ").Append(DepthOrderString).Append("\n");
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
            return this.Equals(input as Box);
        }

        /// <summary>
        /// Returns true if Box instances are equal
        /// </summary>
        /// <param name="input">Instance of Box to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Box input)
        {
            if (input == null)
                return false;

            return base.Equals(input) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && base.Equals(input) &&
                /*(
                    this.Subspace == input.Subspace ||
                    (this.Subspace != null &&
                    this.Subspace.Equals(input.Subspace))
                ) && base.Equals(input) &&*/
                (
                    this.BoxType == input.BoxType ||
                    (this.BoxType != null &&
                    this.BoxType.Equals(input.BoxType))
                ) && base.Equals(input) &&
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && base.Equals(input) &&
                (
                    this.VolumeMax == input.VolumeMax ||
                    (this.VolumeMax != null &&
                    this.VolumeMax.Equals(input.VolumeMax))
                ) && base.Equals(input) &&
                (
                    this.VolumeUsed == input.VolumeUsed ||
                    (this.VolumeUsed != null &&
                    this.VolumeUsed.Equals(input.VolumeUsed))
                ) && base.Equals(input) &&
                (
                    this.VolumeNet == input.VolumeNet ||
                    (this.VolumeNet != null &&
                    this.VolumeNet.Equals(input.VolumeNet))
                ) && base.Equals(input) &&
                (
                    this.VolumeRemaining == input.VolumeRemaining ||
                    (this.VolumeRemaining != null &&
                    this.VolumeRemaining.Equals(input.VolumeRemaining))
                ) && base.Equals(input) &&
                (
                    this.VolumeReserved == input.VolumeReserved ||
                    (this.VolumeReserved != null &&
                    this.VolumeReserved.Equals(input.VolumeReserved))
                ) && base.Equals(input) &&
                (
                    this.VolumeUtilization == input.VolumeUtilization ||
                    (this.VolumeUtilization != null &&
                    this.VolumeUtilization.Equals(input.VolumeUtilization))
                ) && base.Equals(input) &&
                (
                    this.WeightUsed == input.WeightUsed ||
                    (this.WeightUsed != null &&
                    this.WeightUsed.Equals(input.WeightUsed))
                ) && base.Equals(input) &&
                (
                    this.WeightNet == input.WeightNet ||
                    (this.WeightNet != null &&
                    this.WeightNet.Equals(input.WeightNet))
                ) && base.Equals(input) &&
                (
                    this.WeightRemaining == input.WeightRemaining ||
                    (this.WeightRemaining != null &&
                    this.WeightRemaining.Equals(input.WeightRemaining))
                ) && base.Equals(input) &&
                (
                    this.WeightUtilization == input.WeightUtilization ||
                    (this.WeightUtilization != null &&
                    this.WeightUtilization.Equals(input.WeightUtilization))
                ) && base.Equals(input) &&
                (
                    this.DimensionalWeight == input.DimensionalWeight ||
                    (this.DimensionalWeight != null &&
                    this.DimensionalWeight.Equals(input.DimensionalWeight))
                ) && base.Equals(input) &&
                (
                    this.DimensionalWeightUsed == input.DimensionalWeightUsed ||
                    (this.DimensionalWeightUsed != null &&
                    this.DimensionalWeightUsed.Equals(input.DimensionalWeightUsed))
                ) && base.Equals(input) &&
                (
                    this.Svg == input.Svg ||
                    (this.Svg != null &&
                    this.Svg.Equals(input.Svg))
                ) && base.Equals(input) &&
                (
                    this.CenterOfMassString == input.CenterOfMassString ||
                    (this.CenterOfMassString != null &&
                    this.CenterOfMassString.Equals(input.CenterOfMassString))
                ) && base.Equals(input) &&
                (
                    this.DepthOrder == input.DepthOrder ||
                    this.DepthOrder != null &&
                    this.DepthOrder.SequenceEqual(input.DepthOrder)
                ) && base.Equals(input) &&
                (
                    this.DepthOrderString == input.DepthOrderString ||
                    (this.DepthOrderString != null &&
                    this.DepthOrderString.Equals(input.DepthOrderString))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                /*if (this.Subspace != null)
                    hashCode = hashCode * 59 + this.Subspace.GetHashCode();*/
                if (this.BoxType != null)
                    hashCode = hashCode * 59 + this.BoxType.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
                if (this.VolumeMax != null)
                    hashCode = hashCode * 59 + this.VolumeMax.GetHashCode();
                if (this.VolumeUsed != null)
                    hashCode = hashCode * 59 + this.VolumeUsed.GetHashCode();
                if (this.VolumeNet != null)
                    hashCode = hashCode * 59 + this.VolumeNet.GetHashCode();
                if (this.VolumeRemaining != null)
                    hashCode = hashCode * 59 + this.VolumeRemaining.GetHashCode();
                if (this.VolumeReserved != null)
                    hashCode = hashCode * 59 + this.VolumeReserved.GetHashCode();
                if (this.VolumeUtilization != null)
                    hashCode = hashCode * 59 + this.VolumeUtilization.GetHashCode();
                if (this.WeightUsed != null)
                    hashCode = hashCode * 59 + this.WeightUsed.GetHashCode();
                if (this.WeightNet != null)
                    hashCode = hashCode * 59 + this.WeightNet.GetHashCode();
                if (this.WeightRemaining != null)
                    hashCode = hashCode * 59 + this.WeightRemaining.GetHashCode();
                if (this.WeightUtilization != null)
                    hashCode = hashCode * 59 + this.WeightUtilization.GetHashCode();
                if (this.DimensionalWeight != null)
                    hashCode = hashCode * 59 + this.DimensionalWeight.GetHashCode();
                if (this.DimensionalWeightUsed != null)
                    hashCode = hashCode * 59 + this.DimensionalWeightUsed.GetHashCode();
                if (this.Svg != null)
                    hashCode = hashCode * 59 + this.Svg.GetHashCode();
                if (this.CenterOfMassString != null)
                    hashCode = hashCode * 59 + this.CenterOfMassString.GetHashCode();
                if (this.DepthOrder != null)
                    hashCode = hashCode * 59 + this.DepthOrder.GetHashCode();
                if (this.DepthOrderString != null)
                    hashCode = hashCode * 59 + this.DepthOrderString.GetHashCode();
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

            // VolumeMax (decimal?) minimum
            if (this.VolumeMax < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeMax, must be a value greater than or equal to 0.", new[] { "VolumeMax" });
            }

            // VolumeUsed (decimal?) minimum
            if (this.VolumeUsed < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeUsed, must be a value greater than or equal to 0.", new[] { "VolumeUsed" });
            }

            // VolumeNet (decimal?) minimum
            if (this.VolumeNet < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeNet, must be a value greater than or equal to 0.", new[] { "VolumeNet" });
            }

            // VolumeRemaining (decimal?) minimum
            if (this.VolumeRemaining < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeRemaining, must be a value greater than or equal to 0.", new[] { "VolumeRemaining" });
            }

            // VolumeReserved (decimal?) minimum
            if (this.VolumeReserved < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeReserved, must be a value greater than or equal to 0.", new[] { "VolumeReserved" });
            }

            // VolumeUtilization (decimal?) maximum
            if (this.VolumeUtilization > (decimal?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeUtilization, must be a value less than or equal to 1.", new[] { "VolumeUtilization" });
            }

            // VolumeUtilization (decimal?) minimum
            if (this.VolumeUtilization < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for VolumeUtilization, must be a value greater than or equal to 0.", new[] { "VolumeUtilization" });
            }

            // WeightUsed (decimal?) minimum
            if (this.WeightUsed < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightUsed, must be a value greater than or equal to 0.", new[] { "WeightUsed" });
            }

            // WeightNet (decimal?) minimum
            if (this.WeightNet < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightNet, must be a value greater than or equal to 0.", new[] { "WeightNet" });
            }

            // WeightRemaining (decimal?) minimum
            if (this.WeightRemaining < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightRemaining, must be a value greater than or equal to 0.", new[] { "WeightRemaining" });
            }

            // WeightUtilization (decimal?) maximum
            if (this.WeightUtilization > (decimal?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightUtilization, must be a value less than or equal to 1.", new[] { "WeightUtilization" });
            }

            // WeightUtilization (decimal?) minimum
            if (this.WeightUtilization < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for WeightUtilization, must be a value greater than or equal to 0.", new[] { "WeightUtilization" });
            }

            yield break;
        }
    }
}
