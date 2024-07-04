
# Getting Started with Swagger Petstore

## Introduction

This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.

Find out more about Swagger: [http://swagger.io](http://swagger.io)

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package Zee.packagetest --version 1.1.2
```

You can also view the package at:
https://www.nuget.org/packages/Zee.packagetest/1.1.2

## Test the SDK

The generated SDK also contain one or more Tests, which are contained in the Tests project. In order to invoke these test cases, you will need `NUnit 3.0 Test Adapter Extension` for Visual Studio. Once the SDK is complied, the test cases should appear in the Test Explorer window. Here, you can click `Run All` to execute these test cases.

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `TestHeader` | `string` | This is a test header<br>*Default*: `"TestHeaderDefaultValue"` |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `ApiKeyCredentials` | [`ApiKeyCredentials`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/custom-header-signature.md) | The Credentials Setter for Custom Header Signature |
| `HttpBasicCredentials` | [`HttpBasicCredentials`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/basic-authentication.md) | The Credentials Setter for Basic Authentication |
| `PetstoreAuthCredentials` | [`PetstoreAuthCredentials`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/oauth-2-implicit-grant.md) | The Credentials Setter for OAuth 2 Implicit Grant |

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

## Environments

The SDK can be configured to use a different environment for making API calls. Available environments are:

### Fields

| Name | Description |
|  --- | --- |
| production | **Default** |
| environment2 | - |
| environment3 | - |

## Authorization

This API uses the following authentication schemes.

* [`api_key (Custom Header Signature)`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/custom-header-signature.md)
* [`httpBasic (Basic Authentication)`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/basic-authentication.md)
* [`petstore_auth (OAuth 2 Implicit Grant)`](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/$a/https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/oauth-2-implicit-grant.md)

## List of APIs

* [Pet](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/controllers/pet.md)
* [Store](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/controllers/store.md)
* [User](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/controllers/user.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-request.md)
* [HttpResponse](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-string-response.md)
* [HttpContext](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/ZahraN444/zeepackage-1-dotnet-sdk/tree/1.1.2/doc/api-exception.md)

