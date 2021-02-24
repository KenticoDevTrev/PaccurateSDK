using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Paccurate.Enum;

namespace Paccurate.Models
{
    [Serializable]
    [DataContract]
    public class Rule : IEquatable<Rule>, IValidatableObject
    {
        [JsonConstructor]
        public Rule()
        {

        }

        public Rule(OperationEnum? Operation)
        {
            // to ensure "operation" is required (not null)
            if (Operation == null)
            {
                throw new InvalidDataException("operation is a required property for Rule and cannot be null");
            }
            else
            {
                this.Operation = Operation;
            }
        }

        /// <summary>
        /// reference ID for the item the rule applies to.
        /// </summary>
        [DataMember(Name = "itemRefId", EmitDefaultValue = false)]
        public int? ItemRefId { get; set; }

        /// <summary>
        /// target item reference IDs that the rule applies to.
        /// </summary>
        [DataMember(Name = "targetItemRefIds", EmitDefaultValue = false)]
        public List<int?> TargetItemRefIds { get; set; }

        /// <summary>
        /// target box reference IDs that the rule applies to.
        /// </summary>
        /// <value>target box reference IDs that the rule applies to.</value>
        [DataMember(Name = "targetBoxRefIds", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "targetBoxRefIds")]
        public List<int?> TargetBoxRefIds { get; set; }

        /// <summary>
        /// Rule type for this definition. See http://api.paccurate.io/docs/ for Detailed descriptions
        /// </summary>
        [DataMember(Name = "operation", EmitDefaultValue = false)]
        public OperationEnum? Operation { get; set; }



        /// <summary>
        /// Refer to http://api.paccurate.io/docs/ for Options dependign on your Operation
        /// </summary>
        [DataMember(Name = "options", EmitDefaultValue = false)]
        public Dictionary<string, object> Options { get; set; }

        /// <summary>
        /// array of supplementary parameters to pass for rule, mostly deprecated. may be different from options.
        /// </summary>
        [DataMember(Name = "parameters", EmitDefaultValue = false)]
        public Dictionary<string, object> Parameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Rule {\n");
            sb.Append("  ItemRefId: ").Append(ItemRefId).Append("\n");
            sb.Append("  TargetItemRefIds: ").Append(TargetItemRefIds).Append("\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  Options: ").Append(Options).Append("\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
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
            return this.Equals(input as Rule);
        }

        /// <summary>
        /// Returns true if Rule instances are equal
        /// </summary>
        /// <param name="input">Instance of Rule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Rule input)
        {
            if (input == null)
                return false;

            return
                (
                    this.ItemRefId == input.ItemRefId ||
                    (this.ItemRefId != null &&
                    this.ItemRefId.Equals(input.ItemRefId))
                ) &&
                (
                    this.TargetItemRefIds == input.TargetItemRefIds ||
                    this.TargetItemRefIds != null &&
                    this.TargetItemRefIds.SequenceEqual(input.TargetItemRefIds)
                ) &&
                (
                    this.Operation == input.Operation ||
                    (this.Operation != null &&
                    this.Operation.Equals(input.Operation))
                ) &&
                (
                    this.Options == input.Options ||
                    (this.Options != null &&
                    this.Options.Equals(input.Options))
                ) &&
                (
                    this.Parameters == input.Parameters ||
                    this.Parameters != null &&
                    this.Parameters.SequenceEqual(input.Parameters)
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
                if (this.ItemRefId != null)
                    hashCode = hashCode * 59 + this.ItemRefId.GetHashCode();
                if (this.TargetItemRefIds != null)
                    hashCode = hashCode * 59 + this.TargetItemRefIds.GetHashCode();
                if (this.Operation != null)
                    hashCode = hashCode * 59 + this.Operation.GetHashCode();
                if (this.Options != null)
                    hashCode = hashCode * 59 + this.Options.GetHashCode();
                if (this.Parameters != null)
                    hashCode = hashCode * 59 + this.Parameters.GetHashCode();
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
