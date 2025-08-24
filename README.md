# 🍽️ Menu & Order API (C#/.NET 6)

A simple backend API for managing a restaurant-style menu and customer orders.  
Built with **ASP.NET Core Web API** + **Entity Framework Core**.

---

## 📌 Features
- ✅ Manage menu items (Create, Read, Update, Delete)
- ✅ Place orders with one or more menu items
- ✅ Calculate subtotal automatically using snapshots
- ✅ Update order status (Pending → Confirmed / Cancelled)
- ✅ View single order or list of orders
- ✅ Swagger UI for easy testing

---

## 🛠️ Tech Stack
- C# / .NET 6 (ASP.NET Core Web API)
- Entity Framework Core (Code First + Migrations)
- SQL Server LocalDB
- Swagger

---

## 📂 Project Structure
```
📂 Project Structure
MenuAndOrder/
│
├── MenuAndOrder.API/        # ASP.NET Core Web API
│   ├── Controllers/         # API endpoints
│   ├── appsettings.json     # Configuration
│   ├── Program.cs           # Entry point
│
└── MenuAndOrder.Data/       # Data access & business logic
    ├── DatabaseEntities/    # Database entities
    ├── DTOs/                # Data Transfer Objects
    ├── Interfaces/          # Interfaces (IService)
    ├── Services/            # Business logic services
    └── DataContext/         # EF Core DbContext

```

---

## 🚀 Getting Started

### 1️⃣ Clone the repo
```bash
git clone https://github.com/Temidayo99/MenuAndOrderAPI.git
cd MenuOrderApi
```

### 2️⃣ Install dependencies
Make sure you have **.NET 6 SDK** installed.
```bash
dotnet restore
```

### 3️⃣ Update the database
This will create tables and seed initial menu items.
```bash
dotnet ef database update
```

### 4️⃣ Run the app
```bash
dotnet run
```
API will be available at:
👉 https://localhost:{your-port}/swagger (check launchSettings.json for the actual port)

---

## 📖 API Endpoints

### Menu
- `GET /api/v1/menu` → Get all menu items
- `GET /api/v1/menu/{id}` → Get single menu item
- `POST /api/v1/menu` → Add new item
- `PUT /api/v1/menu/{id}` → Update menu item
- `DELETE /api/v1/menu/{id}` → Delete menu item

### Orders
- `POST /api/v1/orders` → Place new order
- `GET /api/v1/orders/{id}` → Get order by ID
- `GET /api/v1/orders` → Get all orders 
- `PATCH /api/v1/orders/{id}/status` → Update order status

---

## 🧪 Sample Data
Seeded menu items (available after first migration):
- 🍚 Jollof Rice — 1500
- 🍗 Chicken Suya — 2500
- 🥤 Zobo Drink — 800

---

## 📝 Example Requests

### Create Menu Item
```http
POST /api/v1/menu
Content-Type: application/json
```
```json
{
  "name": "Chicken Suya",
  "description": "Spicy grilled chicken",
  "price": 2500,
  "isAvailable": true
}
```

### Create Order
```http
POST /api/v1/orders
Content-Type: application/json
```
```json
{
  "customerName": "Ada Love",
  "customerPhone": "+2348000000000",
  "items": [
    { "menuItemId": 1, "quantity": 2 }
  ],
  "notes": "No pepper please"
}
```

### Example Response
```json
{
  "data": {
    "orderId": 5,
    "customerName": "Ada Love",
    "customerPhone": "+2348000000000",
    "subtotal": 3000,
    "status": "Pending"
  },
  "responseCode": "00",
  "responseMessage": "Order created successfully"
}
```

---

## ✅ Acceptance Criteria
- [x] Can manage menu items (CRUD)
- [x] Can place and view orders
- [x] Subtotal is correctly calculated
- [x] Order status can be updated by admin

---

## 📊 Entity Relationships
```
Order (1) —— (many) OrderItem —— (1) MenuItem
```

---

## 👨‍💻 Author
- **Temidayo Oyelami**  
- [GitHub](https://github.com/Temidayo99) | [LinkedIn](https://linkedin.com/in/temidayo-oyelami)
