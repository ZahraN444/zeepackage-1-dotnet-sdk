# Pet

Everything about your Pets

Find out more: [http://swagger.io](http://swagger.io)

```csharp
PetController petController = client.PetController;
```

## Class Name

`PetController`

## Methods

* [Find Pets by Tags](../../doc/controllers/pet.md#find-pets-by-tags)
* [Update Pet](../../doc/controllers/pet.md#update-pet)
* [Add Pet](../../doc/controllers/pet.md#add-pet)
* [Get Pet by Id](../../doc/controllers/pet.md#get-pet-by-id)
* [Find Pets by Status](../../doc/controllers/pet.md#find-pets-by-status)
* [Update Pet With Form](../../doc/controllers/pet.md#update-pet-with-form)
* [Delete Pet](../../doc/controllers/pet.md#delete-pet)
* [Upload File](../../doc/controllers/pet.md#upload-file)


# Find Pets by Tags

**This endpoint is deprecated.**

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

```csharp
FindPetsByTagsAsync(
    List<string> tags)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tags` | `List<string>` | Query, Required | Tags to filter by |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

[`Task<List<Models.Pet>>`](../../doc/models/pet.md)

## Example Usage

```csharp
List<string> tags = new List<string>
{
    "tags5",
    "tags6",
};

try
{
    List<Pet> result = await petController.FindPetsByTagsAsync(tags);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid tag value | `ApiException` |


# Update Pet

Update an existing pet

```csharp
UpdatePetAsync(
    Models.PetRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`PetRequest`](../../doc/models/pet-request.md) | Body, Required | Pet object that needs to be added to the store |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

`Task`

## Example Usage

```csharp
PetRequest body = new PetRequest
{
    Name = "name6",
    PhotoUrls = new List<string>
    {
        "photoUrls1",
    },
};

try
{
    await petController.UpdatePetAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |
| 405 | Validation exception | `ApiException` |


# Add Pet

Add a new pet to the store

```csharp
AddPetAsync(
    Models.PetRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`PetRequest`](../../doc/models/pet-request.md) | Body, Required | Pet object that needs to be added to the store |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

`Task`

## Example Usage

```csharp
PetRequest body = new PetRequest
{
    Name = "name6",
    PhotoUrls = new List<string>
    {
        "photoUrls1",
    },
};

try
{
    await petController.AddPetAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |


# Get Pet by Id

Returns a single pet

```csharp
GetPetByIdAsync(
    long petId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to return |

## Response Type

[`Task<Models.Pet>`](../../doc/models/pet.md)

## Example Usage

```csharp
long petId = 152L;
try
{
    Pet result = await petController.GetPetByIdAsync(petId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |


# Find Pets by Status

Multiple status values can be provided with comma separated strings

```csharp
FindPetsByStatusAsync(
    List<Models.Status2Enum> status)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `status` | [`List<Status2Enum>`](../../doc/models/status-2-enum.md) | Query, Required | Status values that need to be considered for filter |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

[`Task<List<Models.Pet>>`](../../doc/models/pet.md)

## Example Usage

```csharp
List<Status2Enum> status = new List<Status2Enum>
{
    Status2Enum.Pending,
    Status2Enum.Sold,
    Status2Enum.Available,
};

try
{
    List<Pet> result = await petController.FindPetsByStatusAsync(status);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid status value | `ApiException` |


# Update Pet With Form

Updates a pet in the store with form data

```csharp
UpdatePetWithFormAsync(
    long petId,
    Models.ContentTypeEnum contentType,
    string name = null,
    string status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet that needs to be updated |
| `contentType` | [`ContentTypeEnum`](../../doc/models/content-type-enum.md) | Header, Required | - |
| `name` | `string` | Form, Optional | Updated name of the pet |
| `status` | `string` | Form, Optional | Updated status of the pet |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;
ContentTypeEnum contentType = ContentTypeEnum.EnumApplicationxwwwformurlencoded;
try
{
    await petController.UpdatePetWithFormAsync(
        petId,
        contentType
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |


# Delete Pet

Deletes a pet

```csharp
DeletePetAsync(
    long petId,
    string apiKey = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | Pet id to delete |
| `apiKey` | `string` | Header, Optional | - |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;
try
{
    await petController.DeletePetAsync(petId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |


# Upload File

uploads an image

```csharp
UploadFileAsync(
    long petId,
    string additionalMetadata = null,
    FileStreamInfo file = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to update |
| `additionalMetadata` | `string` | Form, Optional | Additional data to pass to server |
| `file` | `FileStreamInfo` | Form, Optional | file to upload |

## Requires scope

### petstore_auth

`read:pets`, `write:pets`

## Response Type

[`Task<Models.ApiResponse>`](../../doc/models/api-response.md)

## Example Usage

```csharp
long petId = 152L;
try
{
    ApiResponse result = await petController.UploadFileAsync(petId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

