# GabriEShop

## Introduction

This is spimple shop application. Users can make orders to buy items from shops.

## Setup

### Prerequisites

Make sure you have installed the following:

- dotnet 3.1 or later

### Building the application

```bash
dotnet build
```

### Running the application

```bash
dotnet run
```

### Database

The application uses a PostgreSQL database.

## API documentation

### Endpoints

### Items

- `GET /items`: Returns a list of all items
- `GET /items{id}`: Returns item with specified id
- `POST /items`: Creates new item
- `PUT /items{id}`: Updates item with specified id
- `DELTE /items{id}`: Deletes item with specified id

### Shops

- `GET /shops`: Returns a list of all shops
- `GET /shops{id}`: Returns shop with specified id
- `POST /shops`: Creates new shop
- `PUT /shops{id}`: Updates shop with specified id
- `DELETE /shops{id}`: Deletes shop with specified id

### Shopping cart

- `PUT /shoppingCart/buy`: Updates shopping cart information

### Users

- `GET /users`: Returns a list of users
- `GET /users{id}`: Returns user with specified id
- `POST /users`: Creates new user
