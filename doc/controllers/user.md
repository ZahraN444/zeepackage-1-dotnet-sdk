# User

Operations about user

Find out more about our store: [http://swagger.io](http://swagger.io)

```csharp
UserController userController = client.UserController;
```

## Class Name

`UserController`

## Methods

* [Create Users With Array Input](../../doc/controllers/user.md#create-users-with-array-input)
* [Update User](../../doc/controllers/user.md#update-user)
* [Create Users With List Input](../../doc/controllers/user.md#create-users-with-list-input)
* [Logout User](../../doc/controllers/user.md#logout-user)
* [Login User](../../doc/controllers/user.md#login-user)
* [Get User by Name](../../doc/controllers/user.md#get-user-by-name)
* [Create User](../../doc/controllers/user.md#create-user)
* [Delete User](../../doc/controllers/user.md#delete-user)


# Create Users With Array Input

Creates list of users with given input array

:information_source: **Note** This endpoint does not require authentication.

```csharp
CreateUsersWithArrayInputAsync(
    List<Models.User> body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`List<User>`](../../doc/models/user.md) | Body, Required | List of user object |

## Response Type

`Task`

## Example Usage

```csharp
List<Models.User> body = new List<Models.User>
{
    new User
    {
    },
};

try
{
    await userController.CreateUsersWithArrayInputAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update User

This can only be done by the logged in user.

:information_source: **Note** This endpoint does not require authentication.

```csharp
UpdateUserAsync(
    string username,
    Models.UserRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `username` | `string` | Template, Required | name that need to be updated |
| `body` | [`UserRequest`](../../doc/models/user-request.md) | Body, Required | Updated user object |

## Response Type

`Task`

## Example Usage

```csharp
string username = "username0";
UserRequest body = new UserRequest
{
};

try
{
    await userController.UpdateUserAsync(
        username,
        body
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
| 400 | Invalid user supplied | `ApiException` |
| 404 | User not found | `ApiException` |


# Create Users With List Input

Creates list of users with given input array

:information_source: **Note** This endpoint does not require authentication.

```csharp
CreateUsersWithListInputAsync(
    List<Models.User> body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`List<User>`](../../doc/models/user.md) | Body, Required | List of user object |

## Response Type

`Task`

## Example Usage

```csharp
List<Models.User> body = new List<Models.User>
{
    new User
    {
    },
};

try
{
    await userController.CreateUsersWithListInputAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Logout User

Logs out current logged in user session

:information_source: **Note** This endpoint does not require authentication.

```csharp
LogoutUserAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await userController.LogoutUserAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Login User

Logs user into the system

:information_source: **Note** This endpoint does not require authentication.

```csharp
LoginUserAsync(
    string username,
    string password)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `username` | `string` | Query, Required | The user name for login |
| `password` | `string` | Query, Required | The password for login in clear text |

## Response Type

`Task<string>`

## Example Usage

```csharp
string username = "username0";
string password = "password4";
try
{
    string result = await userController.LoginUserAsync(
        username,
        password
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
| 400 | Invalid username/password supplied | `ApiException` |


# Get User by Name

Get user by user name

:information_source: **Note** This endpoint does not require authentication.

```csharp
GetUserByNameAsync(
    string username)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `username` | `string` | Template, Required | The name that needs to be fetched. Use user1 for testing. |

## Response Type

[`Task<Models.User>`](../../doc/models/user.md)

## Example Usage

```csharp
string username = "username0";
try
{
    User result = await userController.GetUserByNameAsync(username);
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
| 400 | Invalid username supplied | `ApiException` |
| 404 | User not found | `ApiException` |


# Create User

This can only be done by the logged in user.

:information_source: **Note** This endpoint does not require authentication.

```csharp
CreateUserAsync(
    Models.UserRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`UserRequest`](../../doc/models/user-request.md) | Body, Required | Created user object |

## Response Type

`Task`

## Example Usage

```csharp
UserRequest body = new UserRequest
{
};

try
{
    await userController.CreateUserAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete User

This can only be done by the logged in user.

:information_source: **Note** This endpoint does not require authentication.

```csharp
DeleteUserAsync(
    string username)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `username` | `string` | Template, Required | The name that needs to be deleted |

## Response Type

`Task`

## Example Usage

```csharp
string username = "username0";
try
{
    await userController.DeleteUserAsync(username);
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
| 400 | Invalid username supplied | `ApiException` |
| 404 | User not found | `ApiException` |

