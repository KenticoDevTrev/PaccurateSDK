using System;
using System.Runtime.Serialization;

namespace Paccurate.Models
{
    /// <summary>
    /// Represents a 3 dimentional point, or a length / width / height
    /// </summary>
    [Serializable]
    [DataContract]
    public class Point
    {
        public Point() { }

        /// <summary>
        /// 3 Dimensional Point or Length x Width x Height
        /// </summary>
        /// <param name="x">x coordinate, used as height..</param>
        /// <param name="y">y coordinate, used as width/depth..</param>
        /// <param name="z">z coordinate, used as length..</param>
        public Point(decimal? x, decimal? y, decimal? z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// x coordinate, used as height.
        /// </summary>
        [DataMember(Name = "x", EmitDefaultValue = false)]
        public decimal? X { get; set; }
        /// <summary>
        /// y coordinate, used as width/depth.
        /// </summary>
        [DataMember(Name = "y", EmitDefaultValue = false)]
        public decimal? Y { get; set; }
        /// <summary>
        /// z coordinate, used as length.
        /// </summary>
        [DataMember(Name = "z", EmitDefaultValue = false)]
        public decimal? Z { get; set; }

    }
}