# Mini Grocery Order System

This project is a simple Mini Grocery Order System built as a demo task to
understand backend architecture, business logic handling, and database transactions.

The main focus of this project is **backend responsibility**, not UI design.

---

## Tech Stack

### Backend
- .NET Web API
- Entity Framework Core
- SQL Server

### Frontend
- Basic HTML + JavaScript
- No UI framework (as UI was not the focus)

---

## Project Structure

backend/
- Controllers  
- Services  
- Repositories  
- Models  
- Data  

frontend/
- index.html  
- script.js  

---

## Architecture Overview

The backend follows a clean layered architecture:

- **Controller**  
  Handles HTTP requests and responses only.

- **Service**  
  Contains all business logic such as stock validation, order processing, and transactions.

- **Repository**  
  Handles database operations only.

- **Model**  
  Represents database tables.

No business logic is written inside controllers or frontend.

---

## APIs

### 1. GET /products
Fetches the list of available products.

### 2. POST /orders
Places an order for a product.

This API handles:
- Product existence check
- Stock availability check
- Stock deduction
- Order creation
- Transaction handling

Only these two APIs are implemented as per task rules.

---

## Order Logic Flow

1. Start database transaction
2. Check if product exists
3. Check if stock is sufficient
4. Reduce product stock
5. Create order record
6. Commit transaction
7. Rollback transaction if any step fails

This ensures data consistency and prevents negative stock.

---

## Frontend

The frontend is kept very minimal:
- Displays product list
- Allows placing an order
- Shows success or failure message

No business logic is handled in the frontend.

---

## Notes

- Business logic is strictly placed in the Service layer.
- Controllers are kept thin.
- Only allowed APIs are implemented.
- The project is designed to be easy to understand and explain.

---

## Conclusion

This project demonstrates proper backend responsibility, clean architecture,
and safe transaction handling for a simple order system.
