# CATEGORIES

- [Get all categories](#getAllCategories)
- [Get category by ID](#getCategoryById)
- [Create a category](#createCategory)
- [Update category](#updateCategory)
- [Delete category](#deleteCategory)
- [getProductsByCategoriesId](#getLimitedCategories)

<a id="getAllCategories"></a>

## Get all categories

You can access the list of all categories by using the `/categories` endpoint

### Request:

    [GET] https://shopping-backend.azurewebsites.net/api/v1/categories

### Response:

    [
      {
        "id": "a660ef09-2dc3-40e9-a2db-606556561313",
        "pictureUrl": "https://api.lorem.space/image/face?w=640&h=480&r=867",
        "name": "Clothes"
      },
      // ...
    ]

<a id="getCategoryById"></a>

## Get category by ID

You can get a single category by adding the `id` as a parameter: `/categories/{id}`

### Request:

    [GET] https://shopping-backend.azurewebsites.net/api/v1/categories/1

### Response:

    {
      "id": "a660ef09-2dc3-40e9-a2db-606556561313",
      "pictureUrl": "https://api.lorem.space/image/face?w=640&h=480&r=867",
      "name": "Clothes"
    }

<a id="createCategory"></a>

## Create a category

You can create a new category by sending an object like the following to `/categories`

### Request:

    [POST] https://shopping-backend.azurewebsites.net/api/v1/categories
    # Body
    {
       "file": "<Binary File>",
       "name": "New Category"
    }

    # Headers
    {
      'Content-Type': 'multipart/form-data',"Authorization": "Bearer {your access token}"
    }

### Response:

    {
      "id": "a660ef09-2dc3-40e9-a2db-606556561313",
      "pictureUrl": "https://api.lorem.space/image/face?w=640&h=480&r=867",
      "name": "New Category"
    }

<a id="updateCategory"></a>

## Update a category

You can update a category exists by sending an object like the following and adding the `id` as a parameter: `/categories/{id}`

### Request:

    [PUT] https://shopping-backend.azurewebsites.net/api/v1/categories/1
    # Body
    {
      "name": "Change Name",
      "file": "<Binary File>",
    }

    # Headers
    {
      "Authorization": "Bearer {your access token}"
    }

### Response:

    {
      "id": "a660ef09-2dc3-40e9-a2db-606556561313",
      "pictureUrl": "https://api.lorem.space/image/face?w=640&h=480&r=867",
      "name": "Change Name"
    }

<a id="deleteCategory"></a>

## Delete a category

You can delete a category exists by adding the `id` as a parameter: `/categories/{id}`

### Request:

    [DELETE] https://shopping-backend.azurewebsites.net/api/v1/categories/1

    # Headers
    {
      "Authorization": "Bearer {your access token}"
    }

### Response:

    {
      "message": "success!"
    }

<a id="getProductsByCategoriesId"></a>

## Get limted categories by title

You can fetch all products from categoryId by adding the `id` as a parameter: `/categories/{id}/products`

### Request:

    [GET] https://localhost:7220/api/v1/categories/e47fdac2-7481-449c-8813-4c533dee950a/products

### Response:

    [
      {
        "id": "a660ef09-2dc3-40e9-a2db-606556561313",
        "pictureUrl": "https://api.lorem.space/image/face?w=640&h=480&r=867",
        "name": "Clothes"
      },
      // ... 9 categories with clothes in the title
    ]

[Introduction](../APIEndpoint.md)
