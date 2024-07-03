// <copyright file="OAuthScopePetstoreAuthEnum.cs" company="APIMatic">
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
    using System.Reflection;

    /// <summary>
    /// OAuthScopePetstoreAuthEnum.
    /// </summary>

    [JsonConverter(typeof(StringEnumConverter))]
    public enum OAuthScopePetstoreAuthEnum
    {
        /// <summary>
        ///read your pets
        /// Readpets.
        /// </summary>
        [EnumMember(Value = "read:pets")]
        Readpets,

        /// <summary>
        ///modify pets in your account
        /// Writepets.
        /// </summary>
        [EnumMember(Value = "write:pets")]
        Writepets
    }

    static class OAuthScopePetstoreAuthEnumExtention
    {
        internal static string GetValues(this IEnumerable<OAuthScopePetstoreAuthEnum> values)
        {
            return values != null ? string.Join(" ", values.Select(s => s.GetValue()).Where(s => !string.IsNullOrEmpty(s)).ToArray()) : null;
        }

        private static string GetValue(this Enum value)
        {
            return value.GetType()
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}