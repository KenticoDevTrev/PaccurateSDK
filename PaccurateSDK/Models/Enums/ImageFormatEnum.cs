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
    public enum ImageFormatEnum
    {
        [EnumMember(Value = "svg")]
        Svg = 1,
        [EnumMember(Value = "png")]
        Png = 2
    }
}
