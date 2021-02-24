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

    public enum BoxTypeSetEnum
    {
        /// <summary>
        /// USPS Priority Flat Rate
        /// </summary>
        [EnumMember(Value = "usps")]
        USPS = 1,
        /// <summary>
        /// FedEx OneRate
        /// </summary>
        [EnumMember(Value = "fedex")]
        Fedex = 2,
        /// <summary>
        /// full-, half-, and quarter-sized 48"x40” pallets.
        /// </summary>
        [EnumMember(Value = "pallet")]
        Pallet = 3,
        /// <summary>
        /// Contains some preset of boxes that i'm not 100% sure what they are
        /// </summary>
        [EnumMember(Value = "customer")]
        Customer = 4
    }
}
