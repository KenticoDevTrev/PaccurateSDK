using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    /// <summary>
    /// Rate tables for the packages.  IF using FedEx or UPS, do not need to provide, however if custom or you wish to override, you may do so with this class.
    /// </summary>
    [Serializable]
    [DataContract]
    public class RateTable : IEquatable<RateTable>, IValidatableObject
    {
        public RateTable()
        {

        }

        /// <summary>
        /// carrier name for rate table to use
        /// </summary>
        [DataMember(Name = "carrier", EmitDefaultValue = false)]
        public string Carrier { get; set; }

        /// <summary>
        /// service name for rate table to use
        /// </summary>
        [DataMember(Name = "service", EmitDefaultValue = false)]
        public string Service { get; set; }

        /// <summary>
        /// zone of rate table to use
        /// </summary>
        [DataMember(Name = "zone", EmitDefaultValue = false)]
        public string Zone { get; set; }

        /// <summary>
        /// list of prices to use for the weight that corresponds to its index, e.g., [10, 15, 20] would be $10 for 1lb, $15 for 2lbs, $20 for 3lbs.
        /// </summary>
        [DataMember(Name = "rates", EmitDefaultValue = false)]
        public List<decimal?> Rates { get; set; }

        /// <summary>
        /// list of weights to use for the rate that corresponds to its index, e.g., [1, 2, 3] would mean 1lb for the minimum rate ($10), 2lbs for the second rate ($15), and 3lbs for the highest rate ($20). Note that if the highest value from this list is less than the weightMax of the carton, all carton weights exceeding the maximum from this list up to the carton weightMax will not pro-rate but will be estimated at the maximum value in the rate table.
        /// </summary>
        [DataMember(Name = "weights", EmitDefaultValue = false)]
        public List<decimal?> Weights { get; set; }

        /// <summary>
        /// Instead of providing the full rate table, you can list a carton “basePrice” and a carton "priceIncreaseRate". These two values will be used in a simple linear model to guess carton price, i.e.,
        ///  
        /// cartonPrice = priceIncreaseRate* cartonWeight + basePrice
        /// 
        /// Oftentimes, this will be enough to get accurate carton selections without needing to send complete customer-based rates.It’s worth considering, as the prices are only estimates to be used in carton selection, with final rating of cartons happening outside of paccurate.This is the predicted rate of increase for a weight-based pricing model.The simplest way to find a serviceable value is to take
        /// 
        /// priceIncreaseRate = (maximumPrice - minimumPrice) / (maximumWeight - minimumWeight)
        /// 
        /// In the example above, this would yield
        /// priceIncreaseRate = ($20-$10)/(3lbs-1lb)
        /// priceIncreaseRate = $10/2lbs
        /// priceIncreaseRate = $5/lb
        /// </summary>
        [DataMember(Name = "priceIncreaseRate", EmitDefaultValue = false)]
        public decimal? PriceIncreaseRate { get; set; }

        /// <summary>
        /// The basePrice can be found by estimating the lowest weight-based rate available for a given service, in the example above, solving for basePrice for a $10, 1lb package with the already-solved priceIncreaseRate yields
        /// 
        /// $10 = $5/lb* 1lb + basePrice
        /// $10 = $5 + basePrice
        /// basePrice = $5
        /// </summary>
        [DataMember(Name = "basePrice", EmitDefaultValue = false)]
        public decimal? BasePrice { get; set; }

        /// <summary>
        /// This is the Dimensional Weight divisor. It is given in units of volume per unit weight, e.g., the standard of “139” represents 139 cubic inches per pound, and is used to convert the total volume of a carton into a functional minimum weight to be used when rating the carton. E.g., a carton with dimensions 10" x 10" x 13.9" would yield a volume of 1390 cubic inches. This yields
        /// 
        /// cartonEffectiveMinimumWeight = 1390in³ / 139in³/lb
        /// cartonEffectiveMinimumWeight = 10lbs
        /// </summary>
        [DataMember(Name = "dimFactor", EmitDefaultValue = false)]
        public decimal? DimFactor { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RateTable {\n");
            sb.Append("  Carrier: ").Append(Carrier).Append("\n");
            sb.Append("  Service: ").Append(Service).Append("\n");
            sb.Append("  Zone: ").Append(Zone).Append("\n");
            sb.Append("  Rates: ").Append(Rates).Append("\n");
            sb.Append("  Weights: ").Append(Weights).Append("\n");
            sb.Append("  PriceIncreaseRate: ").Append(PriceIncreaseRate).Append("\n");
            sb.Append("  BasePrice: ").Append(BasePrice).Append("\n");
            sb.Append("  DimFactor: ").Append(DimFactor).Append("\n");
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
            return this.Equals(input as RateTable);
        }

        /// <summary>
        /// Returns true if RateTable instances are equal
        /// </summary>
        /// <param name="input">Instance of RateTable to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RateTable input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Carrier == input.Carrier ||
                    (this.Carrier != null &&
                    this.Carrier.Equals(input.Carrier))
                ) &&
                (
                    this.Service == input.Service ||
                    (this.Service != null &&
                    this.Service.Equals(input.Service))
                ) &&
                (
                    this.Zone == input.Zone ||
                    (this.Zone != null &&
                    this.Zone.Equals(input.Zone))
                ) &&
                (
                    this.Rates == input.Rates ||
                    this.Rates != null &&
                    this.Rates.SequenceEqual(input.Rates)
                ) &&
                (
                    this.Weights == input.Weights ||
                    this.Weights != null &&
                    this.Weights.SequenceEqual(input.Weights)
                ) &&
                (
                    this.PriceIncreaseRate == input.PriceIncreaseRate ||
                    (this.PriceIncreaseRate != null &&
                    this.PriceIncreaseRate.Equals(input.PriceIncreaseRate))
                ) &&
                (
                    this.BasePrice == input.BasePrice ||
                    (this.BasePrice != null &&
                    this.BasePrice.Equals(input.BasePrice))
                ) &&
                (
                    this.DimFactor == input.DimFactor ||
                    (this.DimFactor != null &&
                    this.DimFactor.Equals(input.DimFactor))
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
                if (this.Carrier != null)
                    hashCode = hashCode * 59 + this.Carrier.GetHashCode();
                if (this.Service != null)
                    hashCode = hashCode * 59 + this.Service.GetHashCode();
                if (this.Zone != null)
                    hashCode = hashCode * 59 + this.Zone.GetHashCode();
                if (this.Rates != null)
                    hashCode = hashCode * 59 + this.Rates.GetHashCode();
                if (this.Weights != null)
                    hashCode = hashCode * 59 + this.Weights.GetHashCode();
                if (this.PriceIncreaseRate != null)
                    hashCode = hashCode * 59 + this.PriceIncreaseRate.GetHashCode();
                if (this.BasePrice != null)
                    hashCode = hashCode * 59 + this.BasePrice.GetHashCode();
                if (this.DimFactor != null)
                    hashCode = hashCode * 59 + this.DimFactor.GetHashCode();
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