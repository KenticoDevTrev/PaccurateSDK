using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Paccurate.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationEnum
    {
        // Not doing Internal Space and AlternateDimensions due to more than just a Dictionary for serialization
        // InternalSpace,
        // AlternateDimensions,
        
        /// <summary>
        /// itemRefId is excluded from being packed in the same carton with all targetItemRefIds
        /// </summary>
        [EnumMember(Value = "exclude")]
        Exclude = 1,
        
        /// <summary>
        /// itemRefId is excluded from being packed in the same carton with all items without its refId
        /// </summary>
        [EnumMember(Value = "exclude-all")]
        ExcludeAll = 2,
        
        /// <summary>
        /// Each individual item with itemRefId is packed in a carton matching its exact dimensions, i.e., it is assumed the item is ship-ready and bypasses being placed in a box. If you have an item quantity of 6, it will place the items in 6 boxes.
        /// </summary>
        [EnumMember(Value = "pack-as-is")]
        PackAsIs = 3,

        /// <summary>
        /// There are two types of irregular item packings right now, "nesting" and "roll".
        /// </summary>
        [EnumMember(Value = "irregular")]
        Irregular = 4,

        /// <summary>
        /// itemRefId is locked from rotation of its original dimensions, with axes of rotation excepted by freeAxes
        /// </summary>
        [EnumMember(Value = "lock-orientation")]
        LockOrientation = 5,

        /// <summary>
        /// itemRefId gains conditions for its packing and the packing of items directly above it. Fragile items can be wrapped in a thickness of packing material that is added to each face of the item, or marked as only to be packed on top of other items, or a maximum weight can be given for all additional items supported by the fragile item, or a simple priority flag can be specified where fraile items with the highest priority are never packed underneath items with a lower or unspecified priority.
        /// </summary>
        [EnumMember(Value = "fragile")]
        Fragile = 8
    }
}