# USERS

- [Get all users](#getAllUsers)
- [Get user by ID](#getUserById)
- [Get user profile](#getCurrentUser)

<a id="getAllUsers"></a>

## Get all users

You can access the list of all users by using the `/users` endpoint

### Request:

    [GET] https://shopping-backend.azurewebsites.net/api/v1/users

```
### Response:

[
{
"firstName": "Sumon",
"lastName": "Fakir",
"pictureUrl": "https://res.cloudinary.com/djyuixpkq/image/upload/v1680353757/tbde0q7d35cktgeml08u.jpg",
"publicId": "tbde0q7d35cktgeml08u",
"id": 3,
"userName": "ff2@gmail.com",
"email": "ff2@gmail.com",
}
//...
]

```

<a id="getUserById"></a>

## Get user by ID

You can get a single user by adding the `id` as a parameter: `/users/{id}`

### Request:

    [GET] https://shopping-backend.azurewebsites.net/api/v1/users/1

### Response:

```
{
"firstName": "Sumon",
"lastName": "Fakir",
"pictureUrl": "https://res.cloudinary.com/djyuixpkq/image/upload/v1680353757/tbde0q7d35cktgeml08u.jpg",
"publicId": "tbde0q7d35cktgeml08u",
"id": 3,
"userName": "ff2@gmail.com",
"email": "ff2@gmail.com",
}

```

<a id="getCurrentUser"></a>

## Get user by ID

You can get a user profile by the following endpoint

### Request:

    [GET] https://shopping-backend.azurewebsites.net/api/v1/users/profile

### Response:

```
{
"firstName": "Sumon",
"lastName": "Fakir",
"pictureUrl": "https://res.cloudinary.com/djyuixpkq/image/upload/v1680353757/tbde0q7d35cktgeml08u.jpg",
"publicId": "tbde0q7d35cktgeml08u",
"id": 3,
"userName": "ff2@gmail.com",
"email": "ff2@gmail.com",
}

```

[Introduction](../APIEndpoint.md)
