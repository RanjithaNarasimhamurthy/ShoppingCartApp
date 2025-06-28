# Online Shopping Store

An ASP.NET Core MVC application for an online shopping store featuring product listing, category-based search, and cart management.

---

## Features

- **Home Page** with navigation menu (search bar, Products, Cart)
- **Product Search** by category, with “category not found” fallback
- **Product Detail** pages showing full item information
- **Add to Cart** functionality with success/error prompts
- **View Cart** showing items, quantities, total cost, and “Place Order” or “Continue Shopping” buttons
- **Edit Cart** to update item quantities
- **Delete from Cart** by product ID
- **Checkout** page after placing an order

---

## Technology Stack

- **Framework:** ASP.NET Core MVC  
- **Data Access:** Entity Framework Core (Code-First, Migrations)  
- **Database:** Microsoft SQL Server  
- **Architecture:**  
  - Model classes  
  - `DbContext` class  
  - Repository interfaces & Data Access Layer  
  - Controllers & Razor Views  

---

## Project Structure

/Models # POCO classes representing products, carts, etc.
/Data # DbContext, configuration, migrations
/Interfaces # Repository interfaces for data operations
/Repositories # Concrete implementations of data access
/Controllers # MVC controllers (HomeController, CartController, etc.)
/Views # Razor views (Index, Search, ViewCart, Edit, Delete, ProductDetails, CheckOut)
/wwwroot # Static assets (CSS, JS, images)

---

## Getting Started

1. **Clone the repository**  
   ```bash
   git clone https://github.com/your-username/online-shopping-store.git
   cd online-shopping-store
   
Configure the connection string in appsettings.json


"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ShoppingDb;Trusted_Connection=True;"
}

Apply migrations and create the database

dotnet ef database update

Run the application

dotnet run
Open your browser at https://localhost:5001

Front-End Navigation

Index.cshtml (Home)

Displays navigation menu, search bar, and links to Products and Cart.

Search.cshtml

Lists products matching the searched category. If none match, shows an error and all products.

ViewCart.cshtml

Shows cart items, quantities, and total cost. Prompts on add-to-cart:

“Product added successfully”

“Product already exists in the cart”

Edit.cshtml

Update item quantity in cart; saves changes to the database.

Delete.cshtml

Remove an item by ID with a single click.

ProductDetails.cshtml

Detailed information view for each product.

CheckOut.cshtml

Final order confirmation page after placing the order.

Areas for Improvement

Validate quantity input (non-zero, within data-type limits)

Prevent checkout when any quantity is zero

Apply data annotations for model validation and naming conventions

Add XML comments to all methods for better documentation

Enhance UI/UX (responsive design, client-side validation)

Implement authentication/authorization for user accounts

