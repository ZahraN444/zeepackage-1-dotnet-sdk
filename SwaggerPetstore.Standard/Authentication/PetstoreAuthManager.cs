// <copyright file="PetstoreAuthManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Text;
    using SwaggerPetstore.Standard.Http.Request;
    using SwaggerPetstore.Standard.Utilities;
    using SwaggerPetstore.Standard.Models;
    using APIMatic.Core.Authentication;
    using APIMatic.Core;
    using System.Net.Http;
    using SwaggerPetstore.Standard.Exceptions;

    /// <summary>
    /// PetstoreAuthManager Class.
    /// </summary>
    public class PetstoreAuthManager : AuthManager, IPetstoreAuthCredentials
    {
        private IConfiguration Config;
        private GlobalConfiguration globalConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetstoreAuthManager"/> class.
        /// </summary>
        /// <param name="oAuthClientId"> OAuth 2 Client ID.</param>
        /// <param name="oAuthRedirectUri"> OAuth 2 Redirection URI.</param>
        /// <param name="oAuthToken"> OAuth 2 token.</param>
        /// <param name="oAuthScopes"> List of OAuth 2 scopes.</param>
        internal PetstoreAuthManager(PetstoreAuthModel petstoreAuth)
        {
            this.OAuthClientId = petstoreAuth?.OAuthClientId;
            this.OAuthRedirectUri = petstoreAuth?.OAuthRedirectUri;
            this.OAuthToken = petstoreAuth?.OAuthToken;
            this.OAuthScopes = petstoreAuth?.OAuthScopes;
            Parameters(authParameter => authParameter
                .Header(headerParameter => headerParameter
                    .Setup("Authorization",
                        OAuthToken?.AccessToken == null ? null : $"Bearer {OAuthToken?.AccessToken}"
                    ).Required()));
        }

        /// <summary>
        /// Gets string value for oAuthClientId.
        /// </summary>
        public string OAuthClientId { get; }

        /// <summary>
        /// Gets string value for oAuthRedirectUri.
        /// </summary>
        public string OAuthRedirectUri { get; }

        /// <summary>
        /// Gets Models.OAuthToken value for oAuthToken.
        /// </summary>
        public Models.OAuthToken OAuthToken { get; }

        /// <summary>
        /// Gets List of Models.OAuthScopePetstoreAuthEnum value for oAuthScopes.
        /// </summary>
        public List<Models.OAuthScopePetstoreAuthEnum> OAuthScopes { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="oAuthClientId"> The string value for credentials.</param>
        /// <param name="oAuthRedirectUri"> The string value for credentials.</param>
        /// <param name="oAuthToken"> The Models.OAuthToken value for credentials.</param>
        /// <param name="oAuthScopes"> The List of Models.OAuthScopePetstoreAuthEnum value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string oAuthClientId, string oAuthRedirectUri, Models.OAuthToken oAuthToken, List<Models.OAuthScopePetstoreAuthEnum> oAuthScopes)
        {
            return oAuthClientId.Equals(this.OAuthClientId)
                    && oAuthRedirectUri.Equals(this.OAuthRedirectUri)
                    && ((oAuthToken == null && this.OAuthToken == null) || (oAuthToken != null && this.OAuthToken != null && oAuthToken.Equals(this.OAuthToken)))
                    && ((oAuthScopes == null && this.OAuthScopes == null) || (oAuthScopes != null && this.OAuthScopes != null && oAuthScopes.Equals(this.OAuthScopes)));
        }

        /// <summary>
        /// Checks if token is expired.
        /// </summary>
        /// <returns> Returns true if token is expired.</returns>
        public bool IsTokenExpired()
        {
           if (this.OAuthToken == null)
           {
               throw new InvalidOperationException("OAuth token is missing.");
           }
        
           return this.OAuthToken.Expiry != null
               && this.OAuthToken.Expiry < (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        /// Builds the authorization url for making authorized calls.
        /// </summary>
        /// <param name="state">State</param>        
        /// <param name="additionalParameters">Additional parameters to be appended</param>        
        public string BuildAuthorizationUrl(string state = null, Dictionary<string, object> additionalParameters = null)
        {
            return globalConfiguration.GlobalRequestBuilder(Server.Default)
              .Setup(HttpMethod.Get, "/authorize")
              .Parameters(parameter => parameter
                .Query(queryParameter => queryParameter.Setup("response_type", "code"))
                .Query(queryParameter => queryParameter.Setup("client_id", OAuthClientId))
                .Query(queryParameter => queryParameter.Setup("redirect_uri", OAuthRedirectUri))
                .Query(queryParameter => queryParameter.Setup("scope", OAuthScopes.GetValues()))
                .Query(queryParameter => queryParameter.Setup("state", state))
                .AdditionalQueries(additionalQuery => additionalQuery.Setup(additionalParameters)))
              .Build().QueryUrl;
        }

        public void ApplyGlobalConfiguration(GlobalConfiguration globalConfiguration)
        {
            this.globalConfiguration = globalConfiguration;
        }

        /// <summary>
        /// Validates the authentication parameters for the HTTP Request.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (OAuthToken == null)
            {
                throw new ApiException(
                        "Client is not authorized.An OAuth token is needed to make API calls.");
            }

            if (IsTokenExpired())
            {
                throw new ApiException(
                        "OAuth token is expired. A valid token is needed to make API calls.");
            }
        }

    }

    public sealed class PetstoreAuthModel
    {
        internal PetstoreAuthModel()
        {
        }

        internal string OAuthClientId { get; set; }

        internal string OAuthRedirectUri { get; set; }

        internal Models.OAuthToken OAuthToken { get; set; }

        internal List<Models.OAuthScopePetstoreAuthEnum> OAuthScopes { get; set; }

        /// <summary>
        /// Creates an object of the PetstoreAuthModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(OAuthClientId, OAuthRedirectUri)
                .OAuthToken(OAuthToken)
                .OAuthScopes(OAuthScopes);
        }

        /// <summary>
        /// Builder class for PetstoreAuthModel.
        /// </summary>
        public class Builder
        {
            private string oAuthClientId;
            private string oAuthRedirectUri;
            private Models.OAuthToken oAuthToken;
            private List<Models.OAuthScopePetstoreAuthEnum> oAuthScopes;

            public Builder(string oAuthClientId, string oAuthRedirectUri)
            {
                this.oAuthClientId = oAuthClientId ?? throw new ArgumentNullException(nameof(oAuthClientId));
                this.oAuthRedirectUri = oAuthRedirectUri ?? throw new ArgumentNullException(nameof(oAuthRedirectUri));
            }

            /// <summary>
            /// Sets OAuthClientId.
            /// </summary>
            /// <param name="oAuthClientId">OAuthClientId.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthClientId(string oAuthClientId)
            {
                this.oAuthClientId = oAuthClientId ?? throw new ArgumentNullException(nameof(oAuthClientId));
                return this;
            }


            /// <summary>
            /// Sets OAuthRedirectUri.
            /// </summary>
            /// <param name="oAuthRedirectUri">OAuthRedirectUri.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthRedirectUri(string oAuthRedirectUri)
            {
                this.oAuthRedirectUri = oAuthRedirectUri ?? throw new ArgumentNullException(nameof(oAuthRedirectUri));
                return this;
            }


            /// <summary>
            /// Sets OAuthToken.
            /// </summary>
            /// <param name="oAuthToken">OAuthToken.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthToken(Models.OAuthToken oAuthToken)
            {
                this.oAuthToken = oAuthToken;
                return this;
            }


            /// <summary>
            /// Sets OAuthScopes.
            /// </summary>
            /// <param name="oAuthScopes">OAuthScopes.</param>
            /// <returns>Builder.</returns>
            public Builder OAuthScopes(List<Models.OAuthScopePetstoreAuthEnum> oAuthScopes)
            {
                this.oAuthScopes = oAuthScopes;
                return this;
            }


            /// <summary>
            /// Creates an object of the PetstoreAuthModel using the values provided for the builder.
            /// </summary>
            /// <returns>PetstoreAuthModel.</returns>
            public PetstoreAuthModel Build()
            {
                return new PetstoreAuthModel()
                {
                    OAuthClientId = this.oAuthClientId,
                    OAuthRedirectUri = this.oAuthRedirectUri,
                    OAuthToken = this.oAuthToken,
                    OAuthScopes = this.oAuthScopes
                };
            }
        }
    }
}