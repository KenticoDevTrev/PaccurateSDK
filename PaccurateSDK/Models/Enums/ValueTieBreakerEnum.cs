using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Paccurate.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ValueTieBreakerEnum
    {
        /// <summary>
        /// Tie braker goes to the lowest box volume
        /// </summary>
        [EnumMember(Value = "volume")]
        Volume = 1,
        /// <summary>
        /// Tie breaker goes to the lowest box weight
        /// </summary>
        [EnumMember(Value = "weight")]
        Weight = 2
    }
}
