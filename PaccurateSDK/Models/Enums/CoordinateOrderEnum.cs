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
    // Internal note, that the Priority is ascending, so the first item in the array has LOWEST priority.  Slightly confusing.
    /// <summary>
    /// How the items are placed in the boxes, default prioritizes the Length (left to right), then depth (back to front), then height (bottom to top)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CoordinateOrderEnum
    {
        [EnumMember(Value = "0,1,2")]
        Default = 1,
        [EnumMember(Value = "0,1,2")]
        Length_Depth_Height = 2,
        [EnumMember(Value = "1,0,2")]
        Length_Height_Depth = 3,
        [EnumMember(Value = "0,2,1")]
        Depth_Length_Height = 4,
        [EnumMember(Value = "2,0,1")]
        Depth_Height_Length = 5,
        [EnumMember(Value = "1,2,0")]
        Height_Length_Depth = 6,
        [EnumMember(Value = "2,1,0")]
        Height_Depth_Length = 7
    }
}
