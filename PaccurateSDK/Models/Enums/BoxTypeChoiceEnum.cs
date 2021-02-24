using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Paccurate.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BoxTypeChoiceEnum
    {
        /// <summary>
        /// Attempts real placement of subsequent items in each available boxType and selects the one with the lowest actual cost.
        /// Is much slower than Estimated, but will often return superior cost optimizations.
        /// </summary>
        [EnumMember(Value = "actual")]
        Actual = 1,
        /// <summary>
        /// Uses ‘usableSpace’ to estimate how quickly each valid boxType will be filled by both weight and volume, and estimated cost is calculated.
        /// </summary>
        [EnumMember(Value = "estimated")]
        Estimated = 2
    }
}
