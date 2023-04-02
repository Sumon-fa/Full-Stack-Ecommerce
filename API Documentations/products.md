# PRODUCTS

- [Get all products](#getAllProducts)
- [Get single product](#getSingleProduct)
- [Create new product](#createProduct)
- [Update product](#updateProduct)
- [Delete product](#deleteProduct)

<a id="getAllProducts"></a>

## Get all products​

You can access the list of all users by using the `/products` endpoint

### Request:

    [GET] https://demo.api/api/v1/products

### Response:

    [
      {
       "id": 1,
       "name": "Handmade Fresh Table",
       "price": 687,
       "description": "Andy shoes are designed to keeping in...",
       "pictureUrl": "https://placeimg.com/640/480/any?r=0.8807778235430017"

       // ...
       }
    ]

<a id="getSingleProduct"></a>

## Get Single Product

You can get a single user by adding the `id` as a parameter: `/product/{id}`

### Request:

    ​[GET] https://demo.api/api/v1/products/1

### Response:

    {
       "id": 1,
       "name": "Handmade Fresh Table",
       "price": 687,
       "description": "Andy shoes are designed to keeping in...",
       "pictureUrl": "https://placeimg.com/640/480/any?r=0.8807778235430017"

    }

<a id="createProduct"></a>

## Create Product

You can create a new user by sending an object like the following to `/products`

### Request:

​// Send request in this api with product table

    [POST] https://demo.api/api/v1/products

    # Body
    {
      "id": 1,
      "name": "Handmade Fresh Table",
      "price": 687,
      "description": "Andy shoes are designed to keeping in...",
      "categoryId": 1,
      "file": "<Binary File>",
    }


    # Headers
    {
      'Content-Type': 'multipart/form-data',"Authorization": "Bearer {your access token}"
    }

### Response:

    {
      "id": 210,
      "name": "New Product",
      "price": 10,
      "description": "A description",
      "pictureUrl": "https://placeimg.com/640/480/any",
    }

<a id="updateProduct"></a>

## Update Product

You can update a product exists by sending an object like the following and adding the `id` as a parameter: `/products/{id}`

### Request:

    ​ [PUT] https://demo.api/api/v1/product/1

    {
      ...,
      "name":"Nike"
    }

### Response:

    {
      "id": 210,
      "title": "Nike",
      "price": 10,
      "description": "A description",
      "pictureUrl": "https://placeimg.com/640/480/any.png,
    }

<a id="deleteProduct"></a>

## Delete Product

You can delete a user exists by adding the `id` as a parameter: `/products/{id}`

### Request:

    ​  [DELETE] https://demo.api/api/v1/products/1

### Response:

    {
      "message": "success!"
    }

[Introduction](../APIEndpoint.md)
