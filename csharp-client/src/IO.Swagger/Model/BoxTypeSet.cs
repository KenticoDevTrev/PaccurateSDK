/* 
 * paccurate.io
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.4.4
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// box type sets for useful defaults.
    /// </summary>
    /// <value>box type sets for useful defaults.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum BoxTypeSet
    {
        
        /// <summary>
        /// Enum Usps for value: usps
        /// </summary>
        [EnumMember(Value = "usps")]
        Usps = 1,
        
        /// <summary>
        /// Enum Fedex for value: fedex
        /// </summary>
        [EnumMember(Value = "fedex")]
        Fedex = 2,
        
        /// <summary>
        /// Enum Pallet for value: pallet
        /// </summary>
        [EnumMember(Value = "pallet")]
        Pallet = 3,
        
        /// <summary>
        /// Enum Customer for value: customer
        /// </summary>
        [EnumMember(Value = "customer")]
        Customer = 4
    }

}