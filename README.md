# Order Management API

A simple RESTful Order Management API built with ASP.NET Core (.NET 8) that supports order creation, management, and payments with enforced business rules.

---

## Architecture & Design Decisions

This project follows a layered architecture:

- Endpoints: Handle HTTP requests and responses
- Core: Contain business logic and enforce domain rules
- Repositories: Abstract data storage
- Models: Domain entities
- DTOs: Input/output contracts for the API
- Extensions: COntains any Extension methods/Classes
- SQLite + EF Core: Relational database to persist orders and payments.

This structure improves maintainability, testability, and allows the storage layer to be replaced (e.g., in-memory → SQLite or PostgreSQL) without impacting business logic.

---

## Business Rules Implemented

- An order is considered completed only after a payment is successfully created.
- Completed orders cannot be updated or deleted.
- Payments must reference an existing order.

These rules are enforced at the service layer, not in controllers, to ensure domain consistency.

---

## Storage

The application uses Sql-Lite Storage via repository implementations.
This keeps the setup simple while preserving the ability to swap to SQLite or another database with minimal changes.

---

## Assumptions

- Partial payments are not supported; a single payment completes an order.
- Authentication and authorization are out of scope.
- Items in an order are not stored independently; they exist only as part of the order.
- 

---

## Potential Improvements
- Add authentication & authorization (e.g., JWT)
- Implement pagination & filtering for listing orders/payments
- Use AutoMapper for DTO → Domain mapping
- Add unit & integration tests
- Add logging & monitoring
- Implement better validation for quantities and amounts

## Running the Project

Base Url: https://localhost:7202

```bash
dotnet restore
dotnet run
```

## Endpoints
### Order Endpoints

- **POST** `/orders` – Create a new order with items (body: `CreateOrderDTO`)  
- **GET** `/orders` – List all orders with items  
- **GET** `/orders/{id}` – Get order by ID (with items)  
- **PUT** `/orders/{id}` – Update an order (if not completed, body: `UpdateOrderDTO`)  
- **DELETE** `/orders/{id}` – Delete an order (if not completed)  

### Payment Endpoints

- **POST** `/payment/` – Create a new payment (body: `CreatePaymentDTO`)  
- **GET** `/payment/` – Get all payments  
- **GET** `/payment/items/{id}` – Get payment for a specific order by its ID  
