using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Paccurate.Models
{
    [DataContract]
    [Serializable]
    public class Error
    {
        [JsonConstructor]
        public Error()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Error" /> class.
        /// </summary>
        /// <param name="Message">message (required).</param>
        /// <param name="Details">details.</param>
        /// <param name="Code">code (required).</param>
        public Error(string Error, int Code)
        {
            Message = Error;
            this.Code = Code;
        }

        /// <summary>
        /// The Message of the error
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// The Paccurate error code, between 100 to 600
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public int? Code { get; set; }
    }
}
