/* 
 * paccurate.io
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.4.4
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// set of items sharing a common type.
    /// </summary>
    [DataContract]
    public partial class ItemSet : ItemProperties,  IEquatable<ItemSet>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemSet" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ItemSet() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemSet" /> class.
        /// </summary>
        /// <param name="quantity">quantity of items of this type in this item set.</param>
        public ItemSet(int? quantity = default(int?), int? refId = default(int?), string name = default(string), string color = default(string), decimal? weight = default(decimal?), string sequence = default(string), Object dimensions = default(Object), Object centerOfMass = default(Object), bool? _virtual = false) : base(refId, name, color, weight, sequence, dimensions, centerOfMass, _virtual)
        {
            this.Quantity = quantity;
        }
        
        /// <summary>
        /// quantity of items of this type in this item set
        /// </summary>
        /// <value>quantity of items of this type in this item set</value>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
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
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}