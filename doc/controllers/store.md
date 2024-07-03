# Store

Access to Petstore orders

```csharp
StoreController storeController = client.StoreController;
```

## Class Name

`StoreController`

## Methods

* [Get Order by Id](../../doc/controllers/store.md#get-order-by-id)
* [Place Order](../../doc/controllers/store.md#place-order)
* [Get Inventory](../../doc/controllers/store.md#get-inventory)
* [Delete Order](../../doc/controllers/store.md#delete-order)


# Get Order by Id

For valid response try integer IDs with value >= 1 and <= 10. Other values will generated exceptions

:information_source: **Note** This endpoint does not require authentication.

```csharp
GetOrderByIdAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of pet that needs to be fetched |

## Response Type

[`Task<Models.Order>`](../../doc/models/order.md)

## Example Usage

```csharp
long orderId = 62L;
try
{
    Order result = await storeController.GetOrderByIdAsync(orderId);
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
| 404 | Order not found | `ApiException` |


# Place Order

Place an order for a pet

:information_source: **Note** This endpoint does not require authentication.

```csharp
PlaceOrderAsync(
    Models.StoreOrderRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`StoreOrderRequest`](../../doc/models/store-order-request.md) | Body, Required | order placed for purchasing the pet |

## Response Type

[`Task<Models.Order>`](../../doc/models/order.md)

## Example Usage

```csharp
StoreOrderRequest body = new StoreOrderRequest
{
};

try
{
    Order result = await storeController.PlaceOrderAsync(body);
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
| 400 | Invalid Order | `ApiException` |


# Get Inventory

Returns a map of status codes to quantities

```csharp
GetInventoryAsync()
```

## Response Type

`Task<Dictionary<string, int>>`

## Example Usage

```csharp
try
{
    Dictionary<string, int> result = await storeController.GetInventoryAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete Order

For valid response try integer IDs with positive integer value. Negative or non-integer values will generate API errors

:information_source: **Note** This endpoint does not require authentication.

```csharp
DeleteOrderAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of the order that needs to be deleted |

## Response Type

`Task`

## Example Usage

```csharp
long orderId = 62L;
try
{
    await storeController.DeleteOrderAsync(orderId);
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
| 404 | Order not found | `ApiException` |

