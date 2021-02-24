using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Paccurate.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ItemSortEnum
    {
        /// <summary>
        /// Item volume descending
        /// </summary>
        [EnumMember(Value = "default")]
        Default = 1,
        /// <summary>
        /// By the volume of the smallest box type specified that will fit the item, descending
        /// </summary>
        [EnumMember(Value = "largest-box-needed")]
        LargestBoxNeeded = 2,
        /// <summary>
        /// 2*(width + height), descending
        /// </summary>
        [EnumMember(Value = "largest-girth")]
        LargestGirth = 3,
        /// <summary>
        /// By Longest length, then 2*(width + height), descending
        /// </summary>
        [EnumMember(Value = "largest-length-plus-girth")]
        LargestLengthPlusGirth = 4,
        /// <summary>
        /// By longest single item dimension, descending
        /// </summary>
        [EnumMember(Value = "longest-dimension")]
        LongestDimension = 5,
        /// <summary>
        /// By largest product of the two greatest dimensions, descending
        /// </summary>
        [EnumMember(Value = "largest-cross-section")]
        LargestCrossSection = 6,
        /// <summary>
        /// Uses all possible item sorts and returns the lowest totalCost option
        /// </summary>
        [EnumMember(Value = "combined")]
        Combined = 7
    }
}