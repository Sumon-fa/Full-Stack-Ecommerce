[Introduction](../APIEndpoint.md)

# Orders

This Api endpoint is used to create and read the order histories.

- [Get all order histories](#getAllOrders)
- [Get order histories by user email](#getOrderByUserEmail)
- [Get order by ID](#getOrderByID)
- [Create order](#createOrder)

## Get all order histories]{#getAllOrders}

```
This api gives information of all order histories information.
The data can be limited and pagination is applied by passing the optional parameter as offset and limit in query in request URL.
```

### Request:

```
[GET] https://demo.api/api/v1/orders

Request with pagination pass offset and limit as shown below
[GET] https://demo.api/api/v1/orders?offset=0&limit=10
```

### Response

```
    [
        {
            "id":"ciciuwhoi-899292",
            "status":"pending",
            "customer":"udwihw108-929",
        },
        //...
    ]
```

## Get order histories by user email{#getOrderByUserID}:

```
Using this api you will be able to get all order histories information of specific User by passing the userID parameter.

```

### Request:

```
[GET] https://demo.api/api/v1/myorders


```

### Response

```
   [
    {
        "cartItems": null,
        "customer": "fakrsumon78@gmail.com",
        "status": "Pending",
        "id": "34bd2eea-90b1-40aa-94de-a39184e0306e",
        "createdAt": "2023-04-02T14:24:00.628956",
        "updatedAt": "2023-04-02T14:24:00.628248"
    }
    //
   ]
```

## Get order by ID {#getOrderByID}

```
Using this api you will be able to get order history information of specific Order by passing the orderID in request URL.
```

### Request:

```
[GET] https://demo.api/api/v1/order/ciciuwhoi-899292
```

### Response

```
    {
        "order_id":"ciciuwhoi-899292",
        "status":"pending",
        "user_id":"udwihw108-929",
        "track_number":"dohciudhwoi-12",
        "total":100,
        "cartItems":[
            {
                "cart_id":"xajhcui-bciscs",
                "product_id":"jcisuhcwui-hduidhue",
                "quantity":2,
                "total":20
            },
            {
                "cart_id":"xajhcui-bciscs"d,
                "product_id":"jcisuhcwui-hduidhaue",
                "quantity":1,
                "total":50
            },
            //....
        ],
        "create_date":"01-01-2023"
    }
```

## Create order {#createOrder}

```
This allows to create a new order.
```

### Request

```
[Post] https://demo.api/api/v1/orders

   {
       "cartItems":[
           {
               "productId":"dbf6e5e4-c233-4e2f-b6bb-dfd4a7f8ecbe",
               "updatedPrice":56,
               "amount":1
           }

       ]

}
```

### Response

```
       {
           "cartItems": [
               {
                   "product": null,
                   "productId": "dbf6e5e4-c233-4e2f-b6bb-dfd4a7f8ecbe",
                   "updatedPrice": 56,
                   "amount": 1,
                   "order": null,
                   "orderId": "34bd2eea-90b1-40aa-94de-a39184e0306e",
                   "id": "ad9a80bd-e961-46ce-bf30-343e00b70916",
                   "createdAt": "2023-04-02T14:24:00.6289593+03:00",
                   "updatedAt": "2023-04-02T14:24:00.6282532+03:00"
               }
           ],
           "customer": "fakrsumon78@gmail.com",
           "status": "Pending",
           "id": "34bd2eea-90b1-40aa-94de-a39184e0306e",
           "createdAt": "2023-04-02T14:24:00.6289569+03:00",
           "updatedAt": "2023-04-02T14:24:00.6282487+03:00"
       }
```

[Introduction](../APIEndpoint.md)
