// <copyright file="SwaggerPetstoreClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using SwaggerPetstore.Standard.Authentication;
    using SwaggerPetstore.Standard.Controllers;
    using SwaggerPetstore.Standard.Http.Client;
    using SwaggerPetstore.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class SwaggerPetstoreClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://petstore.swagger.io/v2" },
                }
            },
            {
                Environment.Environment2, new Dictionary<Enum, string>
                {
                    { Server.Default, "http://petstore.swagger.io/v2" },
                }
            },
            {
                Environment.Environment3, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://petstore.swagger.io/oauth" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallBack httpCallBack;
        private readonly Lazy<PetController> pet;
        private readonly Lazy<StoreController> store;
        private readonly Lazy<UserController> user;

        private SwaggerPetstoreClient(
            string testHeader,
            Environment environment,
            ApiKeyModel apiKeyModel,
            HttpBasicModel httpBasicModel,
            PetstoreAuthModel petstoreAuthModel,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.TestHeader = testHeader;
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.HttpClientConfiguration = httpClientConfiguration;
            ApiKeyModel = apiKeyModel;
            var apiKeyManager = new ApiKeyManager(apiKeyModel);
            HttpBasicModel = httpBasicModel;
            var httpBasicManager = new HttpBasicManager(httpBasicModel);
            PetstoreAuthModel = petstoreAuthModel;
            var petstoreAuthManager = new PetstoreAuthManager(petstoreAuthModel);
            petstoreAuthManager.ApplyGlobalConfiguration(globalConfiguration);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"api_key", apiKeyManager},
                    {"httpBasic", httpBasicManager},
                    {"petstore_auth", petstoreAuthManager},
                })
                .ApiCallback(httpCallBack)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .Parameters(globalParameter => globalParameter
                    .Header(headerParameter => headerParameter.Setup("TestHeader", this.TestHeader))
)
                .UserAgent(userAgent)
                .Build();

            ApiKeyCredentials = apiKeyManager;
            HttpBasicCredentials = httpBasicManager;
            PetstoreAuthCredentials = petstoreAuthManager;

            this.pet = new Lazy<PetController>(
                () => new PetController(globalConfiguration));
            this.store = new Lazy<StoreController>(
                () => new StoreController(globalConfiguration));
            this.user = new Lazy<UserController>(
                () => new UserController(globalConfiguration));
        }

        /// <summary>
        /// Gets PetController controller.
        /// </summary>
        public PetController PetController => this.pet.Value;

        /// <summary>
        /// Gets StoreController controller.
        /// </summary>
        public StoreController StoreController => this.store.Value;

        /// <summary>
        /// Gets UserController controller.
        /// </summary>
        public UserController UserController => this.user.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets TestHeader.
        /// This is a test header.
        /// </summary>
        public string TestHeader { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with ApiKey.
        /// </summary>
        public IApiKeyCredentials ApiKeyCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with ApiKey.
        /// </summary>
        public ApiKeyModel ApiKeyModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with HttpBasic.
        /// </summary>
        public IHttpBasicCredentials HttpBasicCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with HttpBasic.
        /// </summary>
        public HttpBasicModel HttpBasicModel { get; private set; }

        /// <summary>
        /// Gets the credentials to use with PetstoreAuth.
        /// </summary>
        public IPetstoreAuthCredentials PetstoreAuthCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with PetstoreAuth.
        /// </summary>
        public PetstoreAuthModel PetstoreAuthModel { get; private set; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the SwaggerPetstoreClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .TestHeader(this.TestHeader)
                .Environment(this.Environment)
                .HttpCallBack(httpCallBack)
                .HttpClientConfig(config => config.Build());

            if (ApiKeyModel != null)
            {
                builder.ApiKeyCredentials(ApiKeyModel.ToBuilder().Build());
            }

            if (HttpBasicModel != null)
            {
                builder.HttpBasicCredentials(HttpBasicModel.ToBuilder().Build());
            }

            if (PetstoreAuthModel != null)
            {
                builder.PetstoreAuthCredentials(PetstoreAuthModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"TestHeader = {this.TestHeader}, " +
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SwaggerPetstoreClient.</returns>
        internal static SwaggerPetstoreClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string testHeader = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_TEST_HEADER");
            string environment = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_ENVIRONMENT");
            string apiKey = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_API_KEY");
            string username = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_USERNAME");
            string passwprd = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_PASSWPRD");
            string oAuthClientId = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_O_AUTH_CLIENT_ID");
            string oAuthRedirectUri = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_O_AUTH_REDIRECT_URI");

            if (testHeader != null)
            {
                builder.TestHeader(testHeader);
            }

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (apiKey != null)
            {
                builder.ApiKeyCredentials(new ApiKeyModel
                .Builder(apiKey)
                .Build());
            }

            if (username != null && passwprd != null)
            {
                builder.HttpBasicCredentials(new HttpBasicModel
                .Builder(username, passwprd)
                .Build());
            }

            if (oAuthClientId != null && oAuthRedirectUri != null)
            {
                builder.PetstoreAuthCredentials(new PetstoreAuthModel
                .Builder(oAuthClientId, oAuthRedirectUri)
                .Build());
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string testHeader = "TestHeaderDefaultValue";
            private Environment environment = SwaggerPetstore.Standard.Environment.Production;
            private ApiKeyModel apiKeyModel = new ApiKeyModel();
            private HttpBasicModel httpBasicModel = new HttpBasicModel();
            private PetstoreAuthModel petstoreAuthModel = new PetstoreAuthModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for ApiKey.
            /// </summary>
            /// <param name="apiKeyModel">ApiKeyModel.</param>
            /// <returns>Builder.</returns>
            public Builder ApiKeyCredentials(ApiKeyModel apiKeyModel)
            {
                if (apiKeyModel is null)
                {
                    throw new ArgumentNullException(nameof(apiKeyModel));
                }

                this.apiKeyModel = apiKeyModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for HttpBasic.
            /// </summary>
            /// <param name="httpBasicModel">HttpBasicModel.</param>
            /// <returns>Builder.</returns>
            public Builder HttpBasicCredentials(HttpBasicModel httpBasicModel)
            {
                if (httpBasicModel is null)
                {
                    throw new ArgumentNullException(nameof(httpBasicModel));
                }

                this.httpBasicModel = httpBasicModel;
                return this;
            }

            /// <summary>
            /// Sets credentials for PetstoreAuth.
            /// </summary>
            /// <param name="petstoreAuthModel">PetstoreAuthModel.</param>
            /// <returns>Builder.</returns>
            public Builder PetstoreAuthCredentials(PetstoreAuthModel petstoreAuthModel)
            {
                if (petstoreAuthModel is null)
                {
                    throw new ArgumentNullException(nameof(petstoreAuthModel));
                }

                this.petstoreAuthModel = petstoreAuthModel;
                return this;
            }

            /// <summary>
            /// Sets TestHeader.
            /// </summary>
            /// <param name="testHeader"> TestHeader. </param>
            /// <returns> Builder. </returns>
            public Builder TestHeader(string testHeader)
            {
                this.testHeader = testHeader ?? throw new ArgumentNullException(nameof(testHeader));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }


           

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the SwaggerPetstoreClient using the values provided for the builder.
            /// </summary>
            /// <returns>SwaggerPetstoreClient.</returns>
            public SwaggerPetstoreClient Build()
            {
                if (apiKeyModel.ApiKey == null)
                {
                    apiKeyModel = null;
                }
                if (httpBasicModel.Username == null || httpBasicModel.Passwprd == null)
                {
                    httpBasicModel = null;
                }
                if (petstoreAuthModel.OAuthClientId == null || petstoreAuthModel.OAuthRedirectUri == null)
                {
                    petstoreAuthModel = null;
                }
                return new SwaggerPetstoreClient(
                    testHeader,
                    environment,
                    apiKeyModel,
                    httpBasicModel,
                    petstoreAuthModel,
                    httpCallBack,
                    httpClientConfig.Build());
            }
        }
    }
}
