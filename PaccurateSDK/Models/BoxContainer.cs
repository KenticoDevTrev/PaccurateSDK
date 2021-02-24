using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Paccurate.Models
{
    /// <summary>
    /// The API sometimes has an array of named Items key values instead of just an array, so for deserialization this is necessary
    /// Example: 
    /// "objects" : [
    ///     "object" : { ... },
    ///     "object" : { ... }
    /// ]
    ///     
    /// vs 
    /// "objects" : [
    ///     { ... },
    ///     { ... }
    /// ]
    /// </summary>
    [DataContract]
    [Serializable]
    public class BoxContainer
    {
        [JsonConstructor]
        public BoxContainer()
        {

        }

        [DataMember(Name = "box", EmitDefaultValue = false)]
        public Box Box { get; set; }
    }
}
