# Buber Breakfast API

- [Buber Dinner API](#buber-breakfast-api)
  - [Auth](#auth)
    - [Register](#register)
        - [Register Request](#register-request)
        - [Register Response](#register-response)
    - [Login](#register)
        - [Login Request](#login-request)
        - [Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

### Register Request

```json
{
  "firstName": "Prince",
  "lastName": "Magutshwa",
  "email": "prince@gmail.com",
  "password": "Prince123!"
}
```

### Login

```js
POST {{host}}/auth/login
```

### Login Request

```json
{
  "email": "prince@gmail.com",
  "password": "Prince123!"
}
```