// <copyright file="ContentTypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using SwaggerPetstore.Standard;
    using SwaggerPetstore.Standard.Utilities;

    /// <summary>
    /// ContentTypeEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentTypeEnum
    {
        /// <summary>
        /// EnumApplicationxwwwformurlencoded.
        /// </summary>
        [EnumMember(Value = "application/x-www-form-urlencoded")]
        EnumApplicationxwwwformurlencoded
    }
}