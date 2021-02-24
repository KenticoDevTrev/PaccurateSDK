using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Paccurate.Models
{
    [Serializable]
    [DataContract]
    public class PackResponse : IEquatable<PackResponse>, IValidatableObject
    {
        public PackResponse()
        {

        }

        /// <summary>
        /// List of boxes, packed, with their contained items.
        /// </summary>
        [DataMember(Name = "boxes", EmitDefaultValue = false)]
        public List<BoxContainer> Boxes { get; set; }

        /// <summary>
        /// title of packing result, when applicable.
        /// </summary>
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }

        /// <summary>
        /// build timestamp of engine.
        /// </summary>
        [DataMember(Name = "built", EmitDefaultValue = false)]
        public string Built { get; set; }

        /// <summary>
        /// version of engine
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }

        /// <summary>
        /// cardinality of all packed boxes
        /// </summary>
        [DataMember(Name = "lenBoxes", EmitDefaultValue = false)]
        public int? LenBoxes { get; set; }

        /// <summary>
        /// cardinality of all items
        /// </summary>
        [DataMember(Name = "lenItems", EmitDefaultValue = false)]
        public int? LenItems { get; set; }

        /// <summary>
        /// cardinality of items unabled to be packed
        /// </summary>
        [DataMember(Name = "lenLeftovers", EmitDefaultValue = false)]
        public int? LenLeftovers { get; set; }

        /// <summary>
        /// total estimated cost of all packed boxes, when applicable, in cents.
        /// </summary>
        [DataMember(Name = "totalCost", EmitDefaultValue = false)]
        public long? TotalCostCents { get; set; }

        /// <summary>
        /// the total cost converted to usd dollars
        /// </summary>
        public decimal? TotalCost => Convert.ToDecimal(TotalCostCents ?? 0m) / 100m;

        /// <summary>
        /// seconds spent in packing
        /// </summary>
        [DataMember(Name = "packTime", EmitDefaultValue = false)]
        public decimal? PackTime { get; set; }

        /// <summary>
        /// seconds spent in rendering and placement instruction creation of packing solution
        /// </summary>
        [DataMember(Name = "renderTime", EmitDefaultValue = false)]
        public decimal? RenderTime { get; set; }

        /// <summary>
        /// seconds spent generating response, total.
        /// </summary>
        [DataMember(Name = "totalTime", EmitDefaultValue = false)]
        public decimal? TotalTime { get; set; }

        /// <summary>
        /// items left over that could not be packed into any available boxes.
        /// </summary>
        [DataMember(Name = "leftovers", EmitDefaultValue = false)]
        public List<ItemContainer> Leftovers { get; set; }

        /// <summary>
        /// name of item sort algorithm used.
        /// </summary>
        [DataMember(Name = "itemSortUsed", EmitDefaultValue = false)]
        public string ItemSortUsed { get; set; }

        /// <summary>
        /// name of box type choice goal used.
        /// </summary>
        [DataMember(Name = "boxTypeChoiceGoalUsed", EmitDefaultValue = false)]
        public string BoxTypeChoiceGoalUsed { get; set; }

        /// <summary>
        /// additional javascripts for any image loading.
        /// </summary>
        [DataMember(Name = "scripts", EmitDefaultValue = false)]
        public string Scripts { get; set; }

        /// <summary>
        /// additional styles for pack images
        /// </summary>
        [DataMember(Name = "styles", EmitDefaultValue = false)]
        public string Styles { get; set; }

        /// <summary>
        /// all box SVG images
        /// </summary>
        [DataMember(Name = "svgs", EmitDefaultValue = false)]
        public List<string> Svgs { get; set; }

        /// <summary>
        /// if PNG imageFormat selected, list of PNG image objects.
        /// </summary>
        [DataMember(Name = "images", EmitDefaultValue = false)]
        public List<Image> Images { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackResponse {\n");
            sb.Append("  Boxes: ").Append(Boxes).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Built: ").Append(Built).Append("\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  LenBoxes: ").Append(LenBoxes).Append("\n");
            sb.Append("  LenItems: ").Append(LenItems).Append("\n");
            sb.Append("  LenLeftovers: ").Append(LenLeftovers).Append("\n");
            sb.Append("  TotalCost: ").Append(TotalCost).Append("\n");
            sb.Append("  PackTime: ").Append(PackTime).Append("\n");
            sb.Append("  RenderTime: ").Append(RenderTime).Append("\n");
            sb.Append("  TotalTime: ").Append(TotalTime).Append("\n");
            sb.Append("  Leftovers: ").Append(Leftovers).Append("\n");
            sb.Append("  ItemSortUsed: ").Append(ItemSortUsed).Append("\n");
            sb.Append("  BoxTypeChoiceGoalUsed: ").Append(BoxTypeChoiceGoalUsed).Append("\n");
            sb.Append("  Scripts: ").Append(Scripts).Append("\n");
            sb.Append("  Styles: ").Append(Styles).Append("\n");
            sb.Append("  Svgs: ").Append(Svgs).Append("\n");
            sb.Append("  Images: ").Append(Images).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PackResponse);
        }

        /// <summary>
        /// Returns true if PackResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of PackResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Boxes == input.Boxes ||
                    this.Boxes != null &&
                    this.Boxes.SequenceEqual(input.Boxes)
                ) &&
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) &&
                (
                    this.Built == input.Built ||
                    (this.Built != null &&
                    this.Built.Equals(input.Built))
                ) &&
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) &&
                (
                    this.LenBoxes == input.LenBoxes ||
                    (this.LenBoxes != null &&
                    this.LenBoxes.Equals(input.LenBoxes))
                ) &&
                (
                    this.LenItems == input.LenItems ||
                    (this.LenItems != null &&
                    this.LenItems.Equals(input.LenItems))
                ) &&
                (
                    this.LenLeftovers == input.LenLeftovers ||
                    (this.LenLeftovers != null &&
                    this.LenLeftovers.Equals(input.LenLeftovers))
                ) &&
                (
                    this.TotalCost == input.TotalCost ||
                    (this.TotalCost != null &&
                    this.TotalCost.Equals(input.TotalCost))
                ) &&
                (
                    this.PackTime == input.PackTime ||
                    (this.PackTime != null &&
                    this.PackTime.Equals(input.PackTime))
                ) &&
                (
                    this.RenderTime == input.RenderTime ||
                    (this.RenderTime != null &&
                    this.RenderTime.Equals(input.RenderTime))
                ) &&
                (
                    this.TotalTime == input.TotalTime ||
                    (this.TotalTime != null &&
                    this.TotalTime.Equals(input.TotalTime))
                ) &&
                (
                    this.Leftovers == input.Leftovers ||
                    this.Leftovers != null &&
                    this.Leftovers.SequenceEqual(input.Leftovers)
                ) &&
                (
                    this.ItemSortUsed == input.ItemSortUsed ||
                    (this.ItemSortUsed != null &&
                    this.ItemSortUsed.Equals(input.ItemSortUsed))
                ) &&
                (
                    this.BoxTypeChoiceGoalUsed == input.BoxTypeChoiceGoalUsed ||
                    (this.BoxTypeChoiceGoalUsed != null &&
                    this.BoxTypeChoiceGoalUsed.Equals(input.BoxTypeChoiceGoalUsed))
                ) &&
                (
                    this.Scripts == input.Scripts ||
                    (this.Scripts != null &&
                    this.Scripts.Equals(input.Scripts))
                ) &&
                (
                    this.Styles == input.Styles ||
                    (this.Styles != null &&
                    this.Styles.Equals(input.Styles))
                ) &&
                (
                    this.Svgs == input.Svgs ||
                    (this.Svgs != null &&
                    this.Svgs.Equals(input.Svgs))
                ) &&
                (
                    this.Images == input.Images ||
                    this.Images != null &&
                    this.Images.SequenceEqual(input.Images)
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
                if (this.Boxes != null)
                    hashCode = hashCode * 59 + this.Boxes.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.Built != null)
                    hashCode = hashCode * 59 + this.Built.GetHashCode();
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.LenBoxes != null)
                    hashCode = hashCode * 59 + this.LenBoxes.GetHashCode();
                if (this.LenItems != null)
                    hashCode = hashCode * 59 + this.LenItems.GetHashCode();
                if (this.LenLeftovers != null)
                    hashCode = hashCode * 59 + this.LenLeftovers.GetHashCode();
                if (this.TotalCost != null)
                    hashCode = hashCode * 59 + this.TotalCost.GetHashCode();
                if (this.PackTime != null)
                    hashCode = hashCode * 59 + this.PackTime.GetHashCode();
                if (this.RenderTime != null)
                    hashCode = hashCode * 59 + this.RenderTime.GetHashCode();
                if (this.TotalTime != null)
                    hashCode = hashCode * 59 + this.TotalTime.GetHashCode();
                if (this.Leftovers != null)
                    hashCode = hashCode * 59 + this.Leftovers.GetHashCode();
                if (this.ItemSortUsed != null)
                    hashCode = hashCode * 59 + this.ItemSortUsed.GetHashCode();
                if (this.BoxTypeChoiceGoalUsed != null)
                    hashCode = hashCode * 59 + this.BoxTypeChoiceGoalUsed.GetHashCode();
                if (this.Scripts != null)
                    hashCode = hashCode * 59 + this.Scripts.GetHashCode();
                if (this.Styles != null)
                    hashCode = hashCode * 59 + this.Styles.GetHashCode();
                if (this.Svgs != null)
                    hashCode = hashCode * 59 + this.Svgs.GetHashCode();
                if (this.Images != null)
                    hashCode = hashCode * 59 + this.Images.GetHashCode();
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
            yield break;
        }
    }
}
