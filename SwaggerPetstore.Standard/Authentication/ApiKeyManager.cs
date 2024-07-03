// <copyright file="ApiKeyManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SwaggerPetstore.Standard.Http.Request;
    using APIMatic.Core.Authentication;

    /// <summary>
    /// ApiKeyManager Class.
    /// </summary>
    internal class ApiKeyManager : AuthManager, IApiKeyCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyManager"/> class.
        /// </summary>
        /// <param name="apiKey">ApiKey.</param>
        public ApiKeyManager(ApiKeyModel apiKeyModel)
        {
            ApiKey = apiKeyModel?.ApiKey;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("api_key", ApiKey).Required())
            );
        }

        /// <summary>
        /// Gets string value for apiKey.
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="apiKey"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string apiKey)
        {
            return apiKey.Equals(this.ApiKey);
        }
    }

    public sealed class ApiKeyModel
    {
        internal ApiKeyModel()
        {
        }

        internal string ApiKey { get; set; }

        /// <summary>
        /// Creates an object of the ApiKeyModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(ApiKey);
        }

        /// <summary>
        /// Builder class for ApiKeyModel.
        /// </summary>
        public class Builder
        {
            private string apiKey;

            public Builder(string apiKey)
            {
                this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            }

            /// <summary>
            /// Sets ApiKey.
            /// </summary>
            /// <param name="apiKey">ApiKey.</param>
            /// <returns>Builder.</returns>
            public Builder ApiKey(string apiKey)
            {
                this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
                return this;
            }


            /// <summary>
            /// Creates an object of the ApiKeyModel using the values provided for the builder.
            /// </summary>
            /// <returns>ApiKeyModel.</returns>
            public ApiKeyModel Build()
            {
                return new ApiKeyModel()
                {
                    ApiKey = this.apiKey
                };
            }
        }
    }
    
}