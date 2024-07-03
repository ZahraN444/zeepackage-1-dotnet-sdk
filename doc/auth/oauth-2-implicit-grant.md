
# OAuth 2 Implicit Grant



Documentation for accessing and setting credentials for petstore_auth.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| OAuthClientId | `string` | OAuth 2 Client ID | `OAuthClientId` | `OAuthClientId` |
| OAuthRedirectUri | `string` | OAuth 2 Redirection endpoint or Callback Uri | `OAuthRedirectUri` | `OAuthRedirectUri` |
| OAuthToken | `Models.OAuthToken` | Object for storing information about the OAuth token | `OAuthToken` | `OAuthToken` |
| OAuthScopes | `List<Models.OAuthScopePetstoreAuthEnum>` | List of scopes that apply to the OAuth token | `OAuthScopes` | `OAuthScopes` |



**Note:** Auth credentials can be set using `PetstoreAuthCredentials` in the client builder and accessed through `PetstoreAuthCredentials` method in the client instance.

## Usage Example



Your application must obtain user authorization before it can execute an endpoint call in case this SDK chooses to use *OAuth 2.0 Implicit Grant* to obtain a user's consent to perform an API request on user's behalf. This authorization includes the following steps

This process requires the presence of a client-side JavaScript code on the redirect URI page to receive the *access token* after the consent step is completed.

### 1\. Obtain user consent

To obtain user's consent, you must redirect the user to the authorization page. The `BuildAuthorizationUrl()` method creates the URL to the authorization page. You must have initialized the client with scopes for which you need permission to access.

```csharp
string authUrl = client.PetstoreAuthCredentials.BuildAuthorizationUrl();
```

### 2\. Handle the OAuth server response

Once the user responds to the consent request, the OAuth 2.0 server responds to your application's access request by redirecting the user to the redirect URI specified set in `Configuration`.

The redirect URI will receive the *access token* as the `token` argument in the URL fragment.

```
https://example.com/oauth/callback#token=XXXXXXXXXXXXXXXXXXXXXXXXX
```

The access token must be extracted by the client-side JavaScript code. The access token can be used to authorize any further endpoint calls by the JavaScript code.

### Scopes

Scopes enable your application to only request access to the resources it needs while enabling users to control the amount of access they grant to your application. Available scopes are defined in the [`OAuthScopePetstoreAuthEnum`](../../doc/models/o-auth-scope-petstore-auth-enum.md) enumeration.

| Scope Name | Description |
|  --- | --- |
| `READPETS` | read your pets |
| `WRITEPETS` | modify pets in your account |


