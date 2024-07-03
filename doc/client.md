
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `TestHeader` | `string` | This is a test header<br>*Default*: `"TestHeaderDefaultValue"` |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `ApiKeyCredentials` | [`ApiKeyCredentials`]($a/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |
| `HttpBasicCredentials` | [`HttpBasicCredentials`]($a/basic-authentication.md) | The Credentials Setter for Basic Authentication |
| `PetstoreAuthCredentials` | [`PetstoreAuthCredentials`]($a/oauth-2-implicit-grant.md) | The Credentials Setter for OAuth 2 Implicit Grant |

The API client can be initialized as follows:

```csharp
SwaggerPetstore.Standard.SwaggerPetstoreClient client = new SwaggerPetstore.Standard.SwaggerPetstoreClient.Builder()
    .ApiKeyCredentials(
        new ApiKeyModel.Builder(
            "api_key"
        )
        .Build())
    .HttpBasicCredentials(
        new HttpBasicModel.Builder(
            "username",
            "passwprd"
        )
        .Build())
    .PetstoreAuthCredentials(
        new PetstoreAuthModel.Builder(
            "OAuthClientId",
            "OAuthRedirectUri"
        )
        .OAuthScopes(
            new List<OAuthScopePetstoreAuthEnum>
            {
                OAuthScopePetstoreAuthEnum.Readpets,
                OAuthScopePetstoreAuthEnum.Writepets,
            })
        .Build())
    .TestHeader("TestHeaderDefaultValue")
    .Environment(SwaggerPetstore.Standard.Environment.Production)
    .Build();
```

## Swagger PetstoreClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| PetController | Gets PetController controller. |
| StoreController | Gets StoreController controller. |
| UserController | Gets UserController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| TestHeader | This is a test header | `string` |
| Environment | Current API environment. | `Environment` |
| ApiKeyCredentials | Gets the credentials to use with ApiKey. | [`IApiKeyCredentials`]($a/custom-header-signature.md) |
| HttpBasicCredentials | Gets the credentials to use with HttpBasic. | [`IHttpBasicCredentials`]($a/basic-authentication.md) |
| PetstoreAuthCredentials | Gets the credentials to use with PetstoreAuth. | [`IPetstoreAuthCredentials`]($a/oauth-2-implicit-grant.md) |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Swagger PetstoreClient using the values provided for the builder. | `Builder` |

## Swagger PetstoreClient Builder Class

Class to build instances of Swagger PetstoreClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `TestHeader(string testHeader)` | This is a test header | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |
| `ApiKeyCredentials(Action<ApiKeyModel.Builder> action)` | Sets credentials for ApiKey. | `Builder` |
| `HttpBasicCredentials(Action<HttpBasicModel.Builder> action)` | Sets credentials for HttpBasic. | `Builder` |
| `PetstoreAuthCredentials(Action<PetstoreAuthModel.Builder> action)` | Sets credentials for PetstoreAuth. | `Builder` |

