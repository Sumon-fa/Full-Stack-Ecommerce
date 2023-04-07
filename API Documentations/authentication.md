[Introduction](../APIEndpoint.md)

# authentication

You can do login by sending an object like the following to /users/signin

### Request

```
[POST] https://shopping-backend.azurewebsites.net/api/v1/users/signin
# Body
{
    "email":"fakrsumon78@gmail.com",
    "password":"1234"
}

### Response

```

{
"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwiaWF0IjoiMDEvMDQvMjAyMyAyMTo1MjoyMCIsImVtYWlsIjoiZmFrcnN1bW9uNzhAZ21haWwuY29tIiwibmFtZSI6ImZha3JzdW1vbjc4QGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjgwMzk2NzQwLCJpc3MiOiJzdW1vbiIsImF1ZCI6ImZzMTMifQ.W4Pn78y0FxOw77BW-e_ffB3QyfFK9iwu5GS090vqiwk",
"expiration": "2023-04-02T03:52:20.7480302+03:00",
}

```

[Introduction](../APIEndpoint.md)
```
