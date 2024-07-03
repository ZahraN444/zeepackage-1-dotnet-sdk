
# Basic Authentication



Documentation for accessing and setting credentials for httpBasic.

## Auth Credentials

| Name | Type | Description | Setter | Getter |
|  --- | --- | --- | --- | --- |
| username | `string` | - | `Username` | `Username` |
| passwprd | `string` | - | `Passwprd` | `Passwprd` |



**Note:** Auth credentials can be set using `HttpBasicCredentials` in the client builder and accessed through `HttpBasicCredentials` method in the client instance.

## Usage Example

### Client Initialization

You must provide credentials in the client as shown in the following code snippet.

```csharp
SwaggerPetstore.Standard.SwaggerPetstoreClient client = new SwaggerPetstore.Standard.SwaggerPetstoreClient.Builder()
    .HttpBasicCredentials(
        new HttpBasicModel.Builder(
            "username",
            "passwprd"
        )
        .Build())
    .Build();
```


