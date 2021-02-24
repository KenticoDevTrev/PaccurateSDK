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
    /// box types to be used for packing.
    /// </summary>
    [DataContract]
    public partial class BoxType : BoxProperties,  IEquatable<BoxType>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxType" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BoxType() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxType" /> class.
        /// </summary>
        public BoxType(string name = default(string), int? refId = default(int?), int? price = default(int?), decimal? weightTare = default(decimal?), decimal? weightMax = default(decimal?), Object dimensions = default(Object), Object centerOfMass = default(Object), Object rateTable = default(Object)) : base(name, refId, price, weightTare, weightMax, dimensions, centerOfMass, rateTable)
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
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
