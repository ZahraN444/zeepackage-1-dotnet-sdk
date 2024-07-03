
# Store Order Request

## Structure

`StoreOrderRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `PetId` | `long?` | Optional | - |
| `Quantity` | `int?` | Optional | - |
| `ShipDate` | `DateTime?` | Optional | - |
| `Status` | [`Status1Enum?`](../../doc/models/status-1-enum.md) | Optional | - |
| `Complete` | `bool?` | Optional | - |

## Example (as JSON)

```json
{
  "id": 240,
  "petId": 24,
  "quantity": 196,
  "shipDate": "2016-03-13T12:52:32.123Z",
  "status": "placed"
}
```

