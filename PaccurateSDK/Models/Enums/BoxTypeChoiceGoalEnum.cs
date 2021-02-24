using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Paccurate.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]

    public enum BoxTypeChoiceGoalEnum
    {
        /// <summary>
        /// Minimizes price or volume cost of boxTypes selected
        /// </summary>
        [EnumMember(Value = "lowest-cost")]
        LowestCost = 1,
        /// <summary>
        /// Maximizes item count per box opened, i.e., fewest total boxes used.
        /// </summary>
        [EnumMember(Value = "most-items")]
        MostItems = 2
    }
}
