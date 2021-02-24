using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Paccurate.Enum;

namespace Paccurate.Models
{
    [Serializable]
    [DataContract]
    public class PackRequest : IEquatable<PackRequest>, IValidatableObject
    {
        public PackRequest()
        {

        }

        public PackRequest(string Key)
        {
            this.Key = Key;
        }

        /// <summary>
        /// issued API key.
        /// </summary>
        [DataMember(Name = "key", EmitDefaultValue = true, Order =1)]
        public string Key { get; set; }

        /// <summary>
        /// default: false
        /// aligns all items laying flat.If possible, it may create a “brick-laying” pattern to increase stability.
        /// </summary>
        [DataMember(Name = "layFlat", EmitDefaultValue = true, Order = 2)]
        public bool? LayFlat { get; set; }

        /// <summary>
        /// default: false
        /// alternates layFlat orientation by layer, so as to create an interlocked placement pattern and improve item stability.
        /// </summary>
        [DataMember(Name = "interlock", EmitDefaultValue = true, Order = 2)]
        public bool? Interlock { get; set; }

        /// <summary>
        /// default: true
        /// only pack items at valid corner points of other items (optimal)
        /// </summary>
        [DataMember(Name = "corners", EmitDefaultValue = true, Order = 2)]
        public bool? Corners { get; set; }

        /// <summary>
        /// item set definitions if not creating random items.
        /// </summary>
        [DataMember(Name = "itemSets", EmitDefaultValue = true, Order = 2)]
        public List<ItemSet> ItemSets { get; set; }

        /// <summary>
        /// box type definitions for packing, will override boxTypeSets defined.
        /// </summary>
        [DataMember(Name = "boxTypes", EmitDefaultValue = true, Order = 2)]
        public List<BoxType> BoxTypes { get; set; }

        /// <summary>
        /// pre-packed boxes, including any items specified that will be packed and excess space used before any new boxes are created.
        /// </summary>
        [DataMember(Name = "boxes", EmitDefaultValue = true, Order = 2)]
        public List<BoxContainer> Boxes { get; set; }

        [NonSerialized]
        private decimal? _UsableSpace;

        /// <summary>
        /// minimum: 0
        /// maximum: 1
        /// default: 0.85
        /// pre-packed boxes, including any items specified that will be packed and excess space used before any new boxes are created.
        /// </summary>
        [DataMember(Name = "usableSpace", EmitDefaultValue = true, Order = 2)]
        public decimal? UsableSpace
        {
            get
            {
                return (_UsableSpace > 1 ? 1 : (_UsableSpace < 0 ? 0 : _UsableSpace));
            }
            set
            {
                _UsableSpace = value;
            }
        }

        [NonSerialized]
        private decimal? _ReservedSpace;

        /// <summary>
        /// minimum: 0
        /// maximum: 1
        /// default: 0
        /// example: 0.2
        /// space in boxes that is reserved, i.e., for packing material.
        /// </summary>
        [DataMember(Name = "reservedSpace", EmitDefaultValue = true, Order = 2)]
        public decimal? ReservedSpace {
            get
            {
                if(!_ReservedSpace.HasValue)
                {
                    return null;
                }
                return (_ReservedSpace > 1 ? 1 : (_ReservedSpace < 0 ? 0 : _ReservedSpace));
            }
            set
            {
                _ReservedSpace = value;
            }
        }

        /// <summary>
        /// predefined box types to be used, separated by commas. Will be overridden by boxTypes if provided
        /// </summary>
        [DataMember(Name="boxTypeSets", EmitDefaultValue = true, Order = 2)]
        public List<BoxTypeSetEnum?> BoxTypeSets { get; set; }


        /// <summary>
        /// The x,y,z coordinates of the virtual eye looking at the package for visualization purposes. Default is isometric, "1,1,1". To generate a side view, one could use "0.001,1.0,0.001"
        /// </summary>
        [DataMember(Name = "eye", EmitDefaultValue = true, Order = 2)]
        public Point Eye { get; set; }

        /// <summary>
        /// the x,y,z coordinates of an optional packing origin. A packing origin is used to create more balanced packing for situations where load needs to be considered. E.g., for a 40"x48" pallet, a packOrigin representing the middle of the pallet, "0,20,24", would cause placement to minimize the distance of the packed items from the center of the pallet.
        /// </summary>
        [DataMember(Name = "packOrigin", EmitDefaultValue = true, Order = 2)]
        public Point PackOrigin { get; set; }

        [NonSerialized]
        private int? _Zone;

        /// <summary>
        /// [experimental] the shipping zone in order to use basic zone-based price optimization.
        /// minimum: 1
        /// </summary>
        [DataMember(Name = "zone", EmitDefaultValue = true, Order = 2)]
        public int? Zone {
            get
            {
                if(!_Zone.HasValue)
                {
                    return null;
                }
                return _Zone < 1 ? 1 : _Zone;
            }
            set
            {
                _Zone = value;
            }
        }

        /// <summary>
        /// Array of packing rules.
        /// </summary>
        [DataMember(Name = "rules", EmitDefaultValue = true, Order = 2)]
        public List<Rule> Rules { get; set; }

        /// <summary>
        /// default: false
        /// create random items
        /// </summary>
        [DataMember(Name = "random", EmitDefaultValue = true, Order = 2)]
        public bool? Random { get; set; }

        /// <summary>
        /// default: 5
        /// number of random items to generate and the quantity of each if “random” is set to true. a value of 5 would create 5 different items with a quantity of 5 each, making the total item quantity equal to n²
        /// </summary>
        [DataMember(Name = "n", EmitDefaultValue = true, Order = 2)]
        public int? N { get; set; }

        /// <summary>
        /// default: 10
        /// maximum item dimension along a single axis for randomly generated items.
        /// </summary>
        [DataMember(Name = "randomMaxDimension", EmitDefaultValue = true, Order = 2)]
        public int? RandomMaxDimension { get; set; }

        /// <summary>
        /// default: 10
        /// maximum item weight for randomly generated items.
        /// </summary>
        [DataMember(Name = "randomMaxWeight", EmitDefaultValue = true, Order = 2)]
        public int? RandomMaxWeight { get; set; }

        /// <summary>
        /// maximum quantity for randomly generated items.
        /// </summary>
        [DataMember(Name = "randomMaxQuantity", EmitDefaultValue = true, Order = 2)]
        public int? RandomMaxQuantity { get; set; }

        /// <summary>
        /// default: true
        /// if random is selected, seed the random number generator to deterministically generate random items to pack.
        /// </summary>
        [DataMember(Name = "seed", EmitDefaultValue = true, Order = 2)]
        public bool? Seed { get; set; }

        /// <summary>
        /// default: 1
        /// if seed is set to true, specifies a non-default seed for the random number generator.
        /// </summary>
        [DataMember(Name = "seedValue", EmitDefaultValue = true, Order = 2)]
        public int? SeedValue { get; set; }

        /// <summary>
        /// default: 400
        /// width of rendered SVGs in pixels.
        /// </summary>
        [DataMember(Name = "imgSize", EmitDefaultValue = true, Order = 2)]
        public int? ImgSize { get; set; }

        /// <summary>
        /// template name for markup generation. Unsure if given options ( demo.tmpl, shipapp.tmpl, boat.tmpl ) are the only ones or you can define your own?
        /// </summary>
        [DataMember(Name = "template", EmitDefaultValue = true, Order = 2)]
        public string Template { get; set; }

        /// <summary>
        /// default: true
        /// include inline javascripts and styles for base template
        /// </summary>
        [DataMember(Name = "includeScripts", EmitDefaultValue = true, Order = 2)]
        public bool? IncludeScripts { get; set; }

        /// <summary>
        /// default: true
        /// include inline images, default is always on
        /// </summary>
        [DataMember(Name = "includeImages", EmitDefaultValue = true, Order = 2)]
        public bool? IncludeImages { get; set; }

        /// <summary>
        /// default: svg
        /// format to render images in, either ‘SVG’ or 'PNG’, if includeImages is enabled.
        /// </summary>
        [DataMember(Name = "imageFormat", EmitDefaultValue = true, Order = 2)]
        public ImageFormatEnum? ImageFormat { get; set; }

        /// <summary>
        /// Box placement ordering
        /// </summary>
        [NonSerialized]
        public CoordinateOrderEnum? CoordinateOrder;

        [DataMember(Name = "coordOrder", EmitDefaultValue = true, Order = 2)]
        public List<int> CoordOrder
        {
            get
            {
                return (CoordinateOrder.HasValue ? CoordinateOrderToArray(CoordinateOrder.Value) : null);
            }
        }

        /// <summary>
        /// default: false
        /// if selected, will ensure that all like items will be packed together, in no more than [cohortMax] different groups within a single container.
        /// </summary>
        [DataMember(Name = "cohortPacking", EmitDefaultValue = true, Order = 2)]
        public bool? CohortPacking { get; set; }

        /// <summary>
        /// default: 2
        /// the maximum number of contiguous cohorts for a given item type within a single container. E.g., if you pack 40 chairs in a single container, a cohortMax of 2 could yield one (all 40 chairs in a single block if space is availabe) or two (say, 25 chairs in one corner and 15 in the other) contiguous cohorts.
        /// </summary>
        [DataMember(Name = "cohortMax", EmitDefaultValue = true, Order = 2)]
        public int? CohortMax { get; set; }

        /// <summary>
        /// default: -1
        /// The amount an item can overhang lower items that it is placed upon. The units are whatever units the box and item dimensions are given in. By convention, inches.
        /// </summary>
        [DataMember(Name = "allowableOverhang", EmitDefaultValue = true, Order = 2)]
        public decimal? AllowableOverhang { get; set; }

        /// <summary>
        /// default: default (use CoordinateOrder)
        /// How to place items.
        /// </summary>
        [DataMember(Name = "placementStyle", EmitDefaultValue = true, Order = 2)]
        public PlacementStyleEnum? PlacementStyle { get; set; }

        /// <summary>
        /// default: combined (uses all possible item sorts and returns the lowest totalCost option)
        /// Method to use to sort items for placement.
        /// </summary>
        [DataMember(Name = "itemSort", EmitDefaultValue = true, Order = 2)]
        public ItemSortEnum? ItemSort { get; set; }

        /// <summary>
        /// default: false
        /// Whether or not to reverse the itemSort utilized.
        /// </summary>
        [DataMember(Name = "itemSortReverse", EmitDefaultValue = true, Order = 2)]
        public bool? ItemSortReverse { get; set; }

        /// <summary>
        /// default: false
        /// For all items where orientation flipping is used, the orientation producing the highest multiple of items fit per remaining dimension is used as the first orientation. This option should be enabled when packing high quantities of single item types, but may produce inconsistent results in other cases. Defers to item orientation locking and itemOrientationSearchDepth > 0 if a superior result is found.
        /// </summary>
        [DataMember(Name = "itemInitialOrientationBestForBox", EmitDefaultValue = true, Order = 2)]
        public bool? ItemInitialOrientationBestForBox { get; set; }

        /// <summary>
        /// default: true
        /// Whether to attempt packing by either greedily placing items or placing all allowable combinations of initial item orientations and selecting the most performant. When true, items will be placed immediately using the orientation reflected by their dimensions definition and will only be flipped if a placement cannot be found and the item rules allow orientation changes. When false, all allowable initial orientation combinations will be attempted for each item in each box.
        /// </summary>
        [DataMember(Name = "itemInitialOrientationPreferred", EmitDefaultValue = true, Order = 2)]
        public bool? ItemInitialOrientationPreferred { get; set; }

        [NonSerialized]
        private int? _ItemOrientationSearchDepth;

        /// <summary>
        /// default: 1
        /// minimum: 0
        /// maximum: 10
        /// When itemInitialOrientationPreferred is set to false, the itemOrientationSearchDepth is the number of unique, sorted, groups of Items sharing the same ItemSet definition that will be have every combination of initial orientation attempted. A value of 1 signifies that only the first item (and others still unpacked from its ItemSet) will have every orientation attempted and the engine subsequently selecting the most performant. A value of 2 signifies that the first groups of unpacked items, each sharing an ItemSet, will have every combination of orientation attempted. Increasing this value from 1 can very rapidly result in excessive complexity and a timeout error instead of a result, so discretion is advised.
        /// </summary>
        [DataMember(Name = "itemOrientationSearchDepth", EmitDefaultValue = true, Order = 2)]
        public int? ItemOrientationSearchDepth {
            get
            {
                if(!_ItemOrientationSearchDepth.HasValue)
                {
                    return null;
                }
                return (_ItemOrientationSearchDepth > 10 ? 1 : (_ItemOrientationSearchDepth < 0 ? 0 : _ItemOrientationSearchDepth));
            }
            set
            {
                _ItemOrientationSearchDepth = value;
            }
        }

        /// <summary>
        /// default: false
        /// Whether or not the items should be initially sorted by their sequence value instead of by the specified itemSort. This is not always useful, as the default “biggest-first” volume sort is very effective for items, and constraining by maxSequenceDistance is applied regardless of this field. That said, for doing custom pre-sorts such as weight-based instead of volume based, this value should be set to true.
        /// </summary>
        [DataMember(Name = "sequenceSort", EmitDefaultValue = true, Order = 2)]
        public bool? SequenceSort { get; set; }

        /// <summary>
        /// default: false
        /// Colorize items solely by their sequence value, light when sequence is high, dark when it is low. Useful for indicating item bin location, weight, or other sequence property that may not be apparent from the default visualization.
        /// </summary>
        [DataMember(Name = "sequenceHeatMap", EmitDefaultValue = true, Order = 2)]
        public bool? SequenceHeatMap { get; set; }

        /// <summary>
        /// This is the maximum distance allowable between two sequence values of items packed in a common box. E.g., “Distance” for an item sequence composed of aisle/bin combinations of “0401” and “1228” has a sequence distance of |1228 - 401| = 827
        /// </summary>
        [DataMember(Name = "maxSequenceDistance", EmitDefaultValue = true, Order = 2)]
        public int? MaxSequenceDistance { get; set;}

        /// <summary>
        /// default: actual
        /// Defines how available boxTypes are selected when a new box must be created to pack additional items.
        /// </summary>
        [DataMember(Name = "boxTypeChoiceStyle", EmitDefaultValue = true, Order = 2)]
        public BoxTypeChoiceEnum? BoxTypeChoiceStyle { get; set; }

        /// <summary>
        /// default: 0
        /// When selecting the next available boxType, we must consider how far to look ahead.
        /// 
        /// Consider we have 8 items of identical dimensions, and two flat rate boxTypes.It is found that Box A can fit 6 items, and costs $12. Box B can fit 4 items, and costs $10.
        /// 
        /// If we consider only the next box, i.e., 'boxTypeChoiceLookahead' set to 0, we would select Box A.It costs $2 per item, whereas Box B is $2.50 per item. Box A is opened, 6 items are placed inside, and now 2 remain.To pack the last 2, Box B would be selected, as 2 items for $10 is $5 per item, and Box A's $12 is $6 per item.
        /// 
        /// Alternatively, if 'boxTypeChoiceLookahead' is set to 1, the boxType that provides the lowest cost per item including the lookahead boxType(s) would be selected. In this case, we find we need 2 of Box B, for $20 total, to fit all 8 items, or $2.50 per item, and would need 1 of Box A and 1 of Box B if Box A is selected first, for $22 total or $2.75 per item. Box B would be used.
        /// 
        /// Please note that 'boxTypeChoiceLookahead', especially when combined with the 'actual' 'boxTypeChoiceStyle' can have significant performance impacts. 0 is recommended for real-time use cases.
        /// </summary>
        [DataMember(Name = "boxTypeChoiceLookahead", EmitDefaultValue = true, Order = 2)]
        public int? BoxTypeChoiceLookahead { get; set; }


        /// <summary>
        /// default: lowest-cost
        /// The objective to evaluate boxTypeChoices by.
        /// </summary>
        [DataMember(Name = "boxTypeChoiceGoal", EmitDefaultValue = true, Order = 2)]
        public BoxTypeChoiceGoalEnum? BoxTypeChoiceGoal { get; set; }

        /// <summary>
        /// default: 0
        /// The maximum number of boxes that a single ItemSet’s member items (i.e., all that share the same refId) can be spread across. Any items that do not fit within this number of boxes will be precluded from packing and returned in the leftovers array. The default setting of 0, a negative number, and null are all equivalent and indicate no maximum limit.
        /// </summary>
        [DataMember(Name = "boxesPerItemSetMax", EmitDefaultValue = true, Order = 2)]
        public int? BoxesPerItemSetMax { get; set; }


        /// <summary>
        /// default: volume
        /// The tiebreaker to use in the event to box type choices are otherwise completely equal. 
        /// </summary>
        [DataMember(Name = "valueTiebreaker", EmitDefaultValue = true, Order = 2)]
        public ValueTieBreakerEnum? ValueTiebreaker { get; set; }


        private List<int> CoordinateOrderToArray(CoordinateOrderEnum value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value
           .GetType()
           .GetField(value.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0 ? attributes[0].Description : "0,1,2").Split(',').Select(x => int.Parse(x)).ToList();
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pack {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  LayFlat: ").Append(LayFlat).Append("\n");
            sb.Append("  Interlock: ").Append(Interlock).Append("\n");
            sb.Append("  Corners: ").Append(Corners).Append("\n");
            sb.Append("  ItemSets: ").Append(ItemSets).Append("\n");
            sb.Append("  BoxTypes: ").Append(BoxTypes).Append("\n");
            sb.Append("  Boxes: ").Append(Boxes).Append("\n");
            sb.Append("  UsableSpace: ").Append(UsableSpace).Append("\n");
            sb.Append("  ReservedSpace: ").Append(ReservedSpace).Append("\n");
            sb.Append("  BoxTypeSets: ").Append(BoxTypeSets).Append("\n");
            sb.Append("  Eye: ").Append(Eye).Append("\n");
            sb.Append("  PackOrigin: ").Append(PackOrigin).Append("\n");
            sb.Append("  Zone: ").Append(Zone).Append("\n");
            sb.Append("  Rules: ").Append(Rules).Append("\n");
            sb.Append("  Random: ").Append(Random).Append("\n");
            sb.Append("  N: ").Append(N).Append("\n");
            sb.Append("  RandomMaxDimension: ").Append(RandomMaxDimension).Append("\n");
            sb.Append("  RandomMaxWeight: ").Append(RandomMaxWeight).Append("\n");
            sb.Append("  RandomMaxQuantity: ").Append(RandomMaxQuantity).Append("\n");
            sb.Append("  Seed: ").Append(Seed).Append("\n");
            sb.Append("  SeedValue: ").Append(SeedValue).Append("\n");
            sb.Append("  ImgSize: ").Append(ImgSize).Append("\n");
            sb.Append("  Template: ").Append(Template).Append("\n");
            sb.Append("  IncludeScripts: ").Append(IncludeScripts).Append("\n");
            sb.Append("  IncludeImages: ").Append(IncludeImages).Append("\n");
            sb.Append("  ImageFormat: ").Append(ImageFormat).Append("\n");
            sb.Append("  CoordOrder: ").Append(CoordOrder).Append("\n");
            sb.Append("  CohortPacking: ").Append(CohortPacking).Append("\n");
            sb.Append("  CohortMax: ").Append(CohortMax).Append("\n");
            sb.Append("  AllowableOverhang: ").Append(AllowableOverhang).Append("\n");
            sb.Append("  PlacementStyle: ").Append(PlacementStyle).Append("\n");
            sb.Append("  ItemSort: ").Append(ItemSort).Append("\n");
            sb.Append("  ItemSortReverse: ").Append(ItemSortReverse).Append("\n");
            sb.Append("  ItemInitialOrientationBestForBox: ").Append(ItemInitialOrientationBestForBox).Append("\n");
            sb.Append("  ItemInitialOrientationPreferred: ").Append(ItemInitialOrientationPreferred).Append("\n");
            sb.Append("  ItemOrientationSearchDepth: ").Append(ItemOrientationSearchDepth).Append("\n");
            sb.Append("  SequenceSort: ").Append(SequenceSort).Append("\n");
            sb.Append("  SequenceHeatMap: ").Append(SequenceHeatMap).Append("\n");
            sb.Append("  MaxSequenceDistance: ").Append(MaxSequenceDistance).Append("\n");
            sb.Append("  BoxTypeChoiceStyle: ").Append(BoxTypeChoiceStyle).Append("\n");
            sb.Append("  BoxTypeChoiceLookahead: ").Append(BoxTypeChoiceLookahead).Append("\n");
            sb.Append("  BoxTypeChoiceGoal: ").Append(BoxTypeChoiceGoal).Append("\n");
            sb.Append("  BoxesPerItemSetMax: ").Append(BoxesPerItemSetMax).Append("\n");
            sb.Append("  ValueTiebreaker: ").Append(ValueTiebreaker).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson(bool format = true)
        {
            return JsonConvert.SerializeObject(this, format ? Formatting.Indented : Formatting.None);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PackRequest);
        }

        /// <summary>
        /// Returns true if Pack instances are equal
        /// </summary>
        /// <param name="input">Instance of Pack to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackRequest input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Key == input.Key ||
                    (this.Key != null &&
                    this.Key.Equals(input.Key))
                ) &&
                (
                    this.LayFlat == input.LayFlat ||
                    (this.LayFlat != null &&
                    this.LayFlat.Equals(input.LayFlat))
                ) &&
                (
                    this.Interlock == input.Interlock ||
                    (this.Interlock != null &&
                    this.Interlock.Equals(input.Interlock))
                ) &&
                (
                    this.Corners == input.Corners ||
                    (this.Corners != null &&
                    this.Corners.Equals(input.Corners))
                ) &&
                (
                    this.ItemSets == input.ItemSets ||
                    this.ItemSets != null &&
                    this.ItemSets.SequenceEqual(input.ItemSets)
                ) &&
                (
                    this.BoxTypes == input.BoxTypes ||
                    this.BoxTypes != null &&
                    this.BoxTypes.SequenceEqual(input.BoxTypes)
                ) &&
                (
                    this.Boxes == input.Boxes ||
                    this.Boxes != null &&
                    this.Boxes.SequenceEqual(input.Boxes)
                ) &&
                (
                    this.UsableSpace == input.UsableSpace ||
                    (this.UsableSpace != null &&
                    this.UsableSpace.Equals(input.UsableSpace))
                ) &&
                (
                    this.ReservedSpace == input.ReservedSpace ||
                    (this.ReservedSpace != null &&
                    this.ReservedSpace.Equals(input.ReservedSpace))
                ) &&
                (
                    this.BoxTypeSets == input.BoxTypeSets ||
                    this.BoxTypeSets != null &&
                    this.BoxTypeSets.SequenceEqual(input.BoxTypeSets)
                ) &&
                (
                    this.Eye == input.Eye ||
                    (this.Eye != null &&
                    this.Eye.Equals(input.Eye))
                ) &&
                (
                    this.PackOrigin == input.PackOrigin ||
                    (this.PackOrigin != null &&
                    this.PackOrigin.Equals(input.PackOrigin))
                ) &&
                (
                    this.Zone == input.Zone ||
                    (this.Zone != null &&
                    this.Zone.Equals(input.Zone))
                ) &&
                (
                    this.Rules == input.Rules ||
                    this.Rules != null &&
                    this.Rules.SequenceEqual(input.Rules)
                ) &&
                (
                    this.Random == input.Random ||
                    (this.Random != null &&
                    this.Random.Equals(input.Random))
                ) &&
                (
                    this.N == input.N ||
                    (this.N != null &&
                    this.N.Equals(input.N))
                ) &&
                (
                    this.RandomMaxDimension == input.RandomMaxDimension ||
                    (this.RandomMaxDimension != null &&
                    this.RandomMaxDimension.Equals(input.RandomMaxDimension))
                ) &&
                (
                    this.RandomMaxWeight == input.RandomMaxWeight ||
                    (this.RandomMaxWeight != null &&
                    this.RandomMaxWeight.Equals(input.RandomMaxWeight))
                ) &&
                (
                    this.RandomMaxQuantity == input.RandomMaxQuantity ||
                    (this.RandomMaxQuantity != null &&
                    this.RandomMaxQuantity.Equals(input.RandomMaxQuantity))
                ) &&
                (
                    this.Seed == input.Seed ||
                    (this.Seed != null &&
                    this.Seed.Equals(input.Seed))
                ) &&
                (
                    this.SeedValue == input.SeedValue ||
                    (this.SeedValue != null &&
                    this.SeedValue.Equals(input.SeedValue))
                ) &&
                (
                    this.ImgSize == input.ImgSize ||
                    (this.ImgSize != null &&
                    this.ImgSize.Equals(input.ImgSize))
                ) &&
                (
                    this.Template == input.Template ||
                    (this.Template != null &&
                    this.Template.Equals(input.Template))
                ) &&
                (
                    this.IncludeScripts == input.IncludeScripts ||
                    (this.IncludeScripts != null &&
                    this.IncludeScripts.Equals(input.IncludeScripts))
                ) &&
                (
                    this.IncludeImages == input.IncludeImages ||
                    (this.IncludeImages != null &&
                    this.IncludeImages.Equals(input.IncludeImages))
                ) &&
                (
                    this.ImageFormat == input.ImageFormat ||
                    (this.ImageFormat != null &&
                    this.ImageFormat.Equals(input.ImageFormat))
                ) &&
                (
                    this.CoordOrder == input.CoordOrder ||
                    this.CoordOrder != null &&
                    this.CoordOrder.SequenceEqual(input.CoordOrder)
                ) &&
                (
                    this.CohortPacking == input.CohortPacking ||
                    (this.CohortPacking != null &&
                    this.CohortPacking.Equals(input.CohortPacking))
                ) &&
                (
                    this.CohortMax == input.CohortMax ||
                    (this.CohortMax != null &&
                    this.CohortMax.Equals(input.CohortMax))
                ) &&
                (
                    this.AllowableOverhang == input.AllowableOverhang ||
                    (this.AllowableOverhang != null &&
                    this.AllowableOverhang.Equals(input.AllowableOverhang))
                ) &&
                (
                    this.PlacementStyle == input.PlacementStyle ||
                    (this.PlacementStyle != null &&
                    this.PlacementStyle.Equals(input.PlacementStyle))
                ) &&
                (
                    this.ItemSort == input.ItemSort ||
                    (this.ItemSort != null &&
                    this.ItemSort.Equals(input.ItemSort))
                ) &&
                (
                    this.ItemSortReverse == input.ItemSortReverse ||
                    (this.ItemSortReverse != null &&
                    this.ItemSortReverse.Equals(input.ItemSortReverse))
                ) &&
                (
                    this.ItemInitialOrientationBestForBox == input.ItemInitialOrientationBestForBox ||
                    (this.ItemInitialOrientationBestForBox != null &&
                    this.ItemInitialOrientationBestForBox.Equals(input.ItemInitialOrientationBestForBox))
                ) &&
                (
                    this.ItemInitialOrientationPreferred == input.ItemInitialOrientationPreferred ||
                    (this.ItemInitialOrientationPreferred != null &&
                    this.ItemInitialOrientationPreferred.Equals(input.ItemInitialOrientationPreferred))
                ) &&
                (
                    this.ItemOrientationSearchDepth == input.ItemOrientationSearchDepth ||
                    (this.ItemOrientationSearchDepth != null &&
                    this.ItemOrientationSearchDepth.Equals(input.ItemOrientationSearchDepth))
                ) &&
                (
                    this.SequenceSort == input.SequenceSort ||
                    (this.SequenceSort != null &&
                    this.SequenceSort.Equals(input.SequenceSort))
                ) &&
                (
                    this.SequenceHeatMap == input.SequenceHeatMap ||
                    (this.SequenceHeatMap != null &&
                    this.SequenceHeatMap.Equals(input.SequenceHeatMap))
                ) &&
                (
                    this.MaxSequenceDistance == input.MaxSequenceDistance ||
                    (this.MaxSequenceDistance != null &&
                    this.MaxSequenceDistance.Equals(input.MaxSequenceDistance))
                ) &&
                (
                    this.BoxTypeChoiceStyle == input.BoxTypeChoiceStyle ||
                    (this.BoxTypeChoiceStyle != null &&
                    this.BoxTypeChoiceStyle.Equals(input.BoxTypeChoiceStyle))
                ) &&
                (
                    this.BoxTypeChoiceLookahead == input.BoxTypeChoiceLookahead ||
                    (this.BoxTypeChoiceLookahead != null &&
                    this.BoxTypeChoiceLookahead.Equals(input.BoxTypeChoiceLookahead))
                ) &&
                (
                    this.BoxTypeChoiceGoal == input.BoxTypeChoiceGoal ||
                    (this.BoxTypeChoiceGoal != null &&
                    this.BoxTypeChoiceGoal.Equals(input.BoxTypeChoiceGoal))
                ) &&
                (
                    this.BoxesPerItemSetMax == input.BoxesPerItemSetMax ||
                    (this.BoxesPerItemSetMax != null &&
                    this.BoxesPerItemSetMax.Equals(input.BoxesPerItemSetMax))
                ) &&
                (
                    this.ValueTiebreaker == input.ValueTiebreaker ||
                    (this.ValueTiebreaker != null &&
                    this.ValueTiebreaker.Equals(input.ValueTiebreaker))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Key != null)
                    hashCode = hashCode * 59 + this.Key.GetHashCode();
                if (this.LayFlat != null)
                    hashCode = hashCode * 59 + this.LayFlat.GetHashCode();
                if (this.Interlock != null)
                    hashCode = hashCode * 59 + this.Interlock.GetHashCode();
                if (this.Corners != null)
                    hashCode = hashCode * 59 + this.Corners.GetHashCode();
                if (this.ItemSets != null)
                    hashCode = hashCode * 59 + this.ItemSets.GetHashCode();
                if (this.BoxTypes != null)
                    hashCode = hashCode * 59 + this.BoxTypes.GetHashCode();
                if (this.Boxes != null)
                    hashCode = hashCode * 59 + this.Boxes.GetHashCode();
                if (this.UsableSpace != null)
                    hashCode = hashCode * 59 + this.UsableSpace.GetHashCode();
                if (this.ReservedSpace != null)
                    hashCode = hashCode * 59 + this.ReservedSpace.GetHashCode();
                if (this.BoxTypeSets != null)
                    hashCode = hashCode * 59 + this.BoxTypeSets.GetHashCode();
                if (this.Eye != null)
                    hashCode = hashCode * 59 + this.Eye.GetHashCode();
                if (this.PackOrigin != null)
                    hashCode = hashCode * 59 + this.PackOrigin.GetHashCode();
                if (this.Zone != null)
                    hashCode = hashCode * 59 + this.Zone.GetHashCode();
                if (this.Rules != null)
                    hashCode = hashCode * 59 + this.Rules.GetHashCode();
                if (this.Random != null)
                    hashCode = hashCode * 59 + this.Random.GetHashCode();
                if (this.N != null)
                    hashCode = hashCode * 59 + this.N.GetHashCode();
                if (this.RandomMaxDimension != null)
                    hashCode = hashCode * 59 + this.RandomMaxDimension.GetHashCode();
                if (this.RandomMaxWeight != null)
                    hashCode = hashCode * 59 + this.RandomMaxWeight.GetHashCode();
                if (this.RandomMaxQuantity != null)
                    hashCode = hashCode * 59 + this.RandomMaxQuantity.GetHashCode();
                if (this.Seed != null)
                    hashCode = hashCode * 59 + this.Seed.GetHashCode();
                if (this.SeedValue != null)
                    hashCode = hashCode * 59 + this.SeedValue.GetHashCode();
                if (this.ImgSize != null)
                    hashCode = hashCode * 59 + this.ImgSize.GetHashCode();
                if (this.Template != null)
                    hashCode = hashCode * 59 + this.Template.GetHashCode();
                if (this.IncludeScripts != null)
                    hashCode = hashCode * 59 + this.IncludeScripts.GetHashCode();
                if (this.IncludeImages != null)
                    hashCode = hashCode * 59 + this.IncludeImages.GetHashCode();
                if (this.ImageFormat != null)
                    hashCode = hashCode * 59 + this.ImageFormat.GetHashCode();
                if (this.CoordOrder != null)
                    hashCode = hashCode * 59 + this.CoordOrder.GetHashCode();
                if (this.CohortPacking != null)
                    hashCode = hashCode * 59 + this.CohortPacking.GetHashCode();
                if (this.CohortMax != null)
                    hashCode = hashCode * 59 + this.CohortMax.GetHashCode();
                if (this.AllowableOverhang != null)
                    hashCode = hashCode * 59 + this.AllowableOverhang.GetHashCode();
                if (this.PlacementStyle != null)
                    hashCode = hashCode * 59 + this.PlacementStyle.GetHashCode();
                if (this.ItemSort != null)
                    hashCode = hashCode * 59 + this.ItemSort.GetHashCode();
                if (this.ItemSortReverse != null)
                    hashCode = hashCode * 59 + this.ItemSortReverse.GetHashCode();
                if (this.ItemInitialOrientationBestForBox != null)
                    hashCode = hashCode * 59 + this.ItemInitialOrientationBestForBox.GetHashCode();
                if (this.ItemInitialOrientationPreferred != null)
                    hashCode = hashCode * 59 + this.ItemInitialOrientationPreferred.GetHashCode();
                if (this.ItemOrientationSearchDepth != null)
                    hashCode = hashCode * 59 + this.ItemOrientationSearchDepth.GetHashCode();
                if (this.SequenceSort != null)
                    hashCode = hashCode * 59 + this.SequenceSort.GetHashCode();
                if (this.SequenceHeatMap != null)
                    hashCode = hashCode * 59 + this.SequenceHeatMap.GetHashCode();
                if (this.MaxSequenceDistance != null)
                    hashCode = hashCode * 59 + this.MaxSequenceDistance.GetHashCode();
                if (this.BoxTypeChoiceStyle != null)
                    hashCode = hashCode * 59 + this.BoxTypeChoiceStyle.GetHashCode();
                if (this.BoxTypeChoiceLookahead != null)
                    hashCode = hashCode * 59 + this.BoxTypeChoiceLookahead.GetHashCode();
                if (this.BoxTypeChoiceGoal != null)
                    hashCode = hashCode * 59 + this.BoxTypeChoiceGoal.GetHashCode();
                if (this.BoxesPerItemSetMax != null)
                    hashCode = hashCode * 59 + this.BoxesPerItemSetMax.GetHashCode();
                if (this.ValueTiebreaker != null)
                    hashCode = hashCode * 59 + this.ValueTiebreaker.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // UsableSpace (decimal?) maximum
            if (this.UsableSpace > (decimal?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for UsableSpace, must be a value less than or equal to 1.", new[] { "UsableSpace" });
            }

            // UsableSpace (decimal?) minimum
            if (this.UsableSpace < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for UsableSpace, must be a value greater than or equal to 0.", new[] { "UsableSpace" });
            }

            // ReservedSpace (decimal?) maximum
            if (this.ReservedSpace > (decimal?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReservedSpace, must be a value less than or equal to 1.", new[] { "ReservedSpace" });
            }

            // ReservedSpace (decimal?) minimum
            if (this.ReservedSpace < (decimal?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ReservedSpace, must be a value greater than or equal to 0.", new[] { "ReservedSpace" });
            }

            // Zone (int?) minimum
            if (this.Zone < (int?)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Zone, must be a value greater than or equal to 1.", new[] { "Zone" });
            }

            // ItemOrientationSearchDepth (int?) maximum
            if (this.ItemOrientationSearchDepth > (int?)10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ItemOrientationSearchDepth, must be a value less than or equal to 10.", new[] { "ItemOrientationSearchDepth" });
            }

            // ItemOrientationSearchDepth (int?) minimum
            if (this.ItemOrientationSearchDepth < (int?)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ItemOrientationSearchDepth, must be a value greater than or equal to 0.", new[] { "ItemOrientationSearchDepth" });
            }

            yield break;
        }
    }
}
