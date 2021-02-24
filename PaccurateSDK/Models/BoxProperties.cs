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
    public class BoxProperties : IEquatable<BoxProperties>, IValidatableObject
    {
        [JsonConstructor]
        public BoxProperties()
        {

        }

        public BoxProperties(decimal? WeightMax, Point Dimensions)
        {
            // to ensure "weightMax" is required (not null)
            if (WeightMax == null)
            {
                throw new InvalidDataException("weightMax is a required property for BoxProperties and cannot be null");
            }
            else
            {
                this.WeightMax = WeightMax;
            }
            // to ensure "dimensions" is required (not null)
            if (Dimensions == null)
            {
                throw new InvalidDataException("dimensions is a required property for BoxProperties and cannot be null");
            }
            else
            {
                this.Dimensions = Dimensions;
            }
        }

        /// <summary>
        /// name for the type of box.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// box type reference identifier passed backed from request.
        /// </summary>
        [DataMember(Name = "refId", EmitDefaultValue = false)]
        public int? RefId { get; set; }

        /// <summary>
        /// minimum: 0
        /// Fixed price of the container, in whole units of currency, default USD cents. This can represent the cost of a flat rate carton, the cost of the actual carton materials, or it can include any other flat fees that may need to be added on a per-carton basis, such as handling, accessorial surchages, oversize fees, etc. This value is added to any rate table rates defined for the carton.
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public long? PriceCents { get; set; }

        /// <summary>
        /// minimum 0, get set value of the USD Dollars
        /// </summary>
        public decimal? Price {
            get {
                return Convert.ToDecimal(PriceCents ?? 0m) / 100m;
            }
            set {
                PriceCents = Convert.ToInt64((value ?? 0m) * 100);
            }
        }

        /// <summary>
        /// minimum: 0
        /// default: 0
        /// weight of the container when empty or otherwise unladen, i.e., of the box itself.
        /// </summary>
        [DataMember(Name = "weightTare", EmitDefaultValue = false)]
        public decimal? WeightTare { get; set; }

        /// <summary>
        /// minimum: 0
        /// maximum allowable gross weight for the box, i.e., all packed item weights plus the weightTare.
        /// </summary>
        [DataMember(Name = "weightMax", EmitDefaultValue = false)]
        public decimal? WeightMax { get; set; }

        /// <summary>
        /// the [height,length,width] of the box.
        /// </summary>
        [DataMember(Name = "dimensions", EmitDefaultValue = false)]
        public Point Dimensions { get; set; }

        /// <summary>
        /// the coordinates of the center of mass of the box.
        /// </summary>
        [DataMember(Name = "centerOfMass", EmitDefaultValue = false)]
        public Point CenterOfMass { get; set; }

        /// <summary>
        /// An optional rate table definition for improved carton selection and pricing optimization. Defaults are included using retail rates for FedEx and UPS if carrier and service is provided, but optimization can be improved with more data passed in a carton’s specific rate table. Methods are
        /// 1. Provide carrier, service, and zone.
        /// 2. Provide all acceptable weights and prices to use for the carton, similar to actual carrier rate tables.
        /// 3.Provide the coefficients required for a simple linear weight-dependent pricing model.
        /// </summary>
        [DataMember(Name = "rateTable", EmitDefaultValue = false)]
        public RateTable RateTable { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BoxProperties {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RefId: ").Append(RefId).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  WeightTare: ").Append(WeightTare).Append("\n");
            sb.Append("  WeightMax: ").Append(WeightMax).Append("\n");
            sb.Append("  Dimensions: ").Append(Dimensions).Append("\n");
            sb.Append("  CenterOfMass: ").Append(CenterOfMass).Append("\n");
            sb.Append("  RateTable: ").Append(RateTable).Append("\n");
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
            return this.Equals(input as BoxProperties);
        }

        /// <summary>
        /// Returns true if BoxProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of BoxProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BoxProperties input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) &&
                (
                    this.RefId == input.RefId ||
                    (this.RefId != null &&
                    this.RefId.Equals(input.RefId))
                ) &&
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) &&
                (
                    this.WeightTare == input.WeightTare ||
                    (this.WeightTare != null &&
                    this.WeightTare.Equals(input.WeightTare))
                ) &&
                (
                    this.WeightMax == input.WeightMax ||
                    (this.WeightMax != null &&
                    this.WeightMax.Equals(input.WeightMax))
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
                    this.RateTable == input.RateTable ||
                    (this.RateTable != null &&
                    this.RateTable.Equals(input.RateTable))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.RefId != null)
                    hashCode = hashCode * 59 + this.RefId.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.WeightTare != null)
                    hashCode = hashCode * 59 + this.WeightTare.GetHashCode();
                if (this.WeightMax != null)
                    hashCode = hashCode * 59 + this.WeightMax.GetHashCode();
                if (this.Dimensions != null)
                    hashCode = hashCode * 59 + this.Dimensions.GetHashCode();
                if (this.CenterOfMass != null)
                    hashCode = hashCode * 59 + this.CenterOfMass.GetHashCode();
                if (this.RateTable != null)
                    hashCode = hashCode * 59 + this.RateTable.GetHashCode();
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
