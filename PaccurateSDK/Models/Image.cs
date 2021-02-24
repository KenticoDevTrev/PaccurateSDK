using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Paccurate.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    [DataContract]
    public class Image : IEquatable<Image>, IValidatableObject
    {
        public Image()
        {

        }
        /// <summary>
        /// the index (Box.id) of the box pack the image is a representation of.
        /// </summary>
        [DataMember(Name = "boxIndex", EmitDefaultValue = false)]
        public int? BoxIndex { get; set; }

        /// <summary>
        /// the image format of the data property.
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public ImageFormatEnum? Format { get; set; }

        /// <summary>
        /// base64-encoded image data.
        /// </summary>
        [DataMember(Name = "data", EmitDefaultValue = false)]
        public string Data { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Image {\n");
            sb.Append("  BoxIndex: ").Append(BoxIndex).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
            sb.Append("  Data: ").Append(Data).Append("\n");
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
            return this.Equals(input as Image);
        }

        /// <summary>
        /// Returns true if Image instances are equal
        /// </summary>
        /// <param name="input">Instance of Image to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Image input)
        {
            if (input == null)
                return false;

            return
                (
                    this.BoxIndex == input.BoxIndex ||
                    (this.BoxIndex != null &&
                    this.BoxIndex.Equals(input.BoxIndex))
                ) &&
                (
                    this.Format == input.Format ||
                    (this.Format != null &&
                    this.Format.Equals(input.Format))
                ) &&
                (
                    this.Data == input.Data ||
                    (this.Data != null &&
                    this.Data.Equals(input.Data))
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
                if (this.BoxIndex != null)
                    hashCode = hashCode * 59 + this.BoxIndex.GetHashCode();
                if (this.Format != null)
                    hashCode = hashCode * 59 + this.Format.GetHashCode();
                if (this.Data != null)
                    hashCode = hashCode * 59 + this.Data.GetHashCode();
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
