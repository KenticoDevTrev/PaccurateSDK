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
    public enum PlacementStyleEnum
    {
        /// <summary>
        /// Will defer to coordOrder
        /// </summary>
        [EnumMember(Value = "default")]
        Default = 1,
        /// <summary>
        /// minimizes distance to rear, bottom corner
        /// </summary>
        [EnumMember(Value = "corner")]
        Corner = 2,
        /// <summary>
        /// minimizes distance to middle of bottom, back edge
        /// </summary>
        [EnumMember(Value = "wedge")]
        Wedge = 3,
        /// <summary>
        /// minimizes distance to center of carton bottom
        /// </summary>
        [EnumMember(Value = "mound")]
        Mound = 4,
        /// <summary>
        /// orb?
        /// </summary>
        [EnumMember(Value = "orb")]
        Orb = 4
    }
}
