<!DOCTYPE html>
<html lang="en">
<body>
    <div class="container">
        <h1>Product Service - Design Document</h1>
        <h2>Overview</h2>
        <p>This .NET Core 8 Web API project provides CRUD operations for managing products using Entity Framework Core 8. The API follows a layered architecture with controller, service, and repository layers.</p>
        <h2>Technologies Used</h2>
        <ul>
            <li><strong>.NET Core 8</strong> - Web API framework</li>
            <li><strong>Entity Framework Core 8</strong> - ORM for database interaction</li>
            <li><strong>SQL Server</strong> - Database</li>
            <li><strong>Dependency Injection</strong> - For better modularity and testability</li>
            <li><strong>Swagger</strong> - API documentation</li>
        </ul>
        <h2>API Endpoints</h2>
        <h3>1. Get All Products</h3>
        <p><code>GET /api/products/product_shortlist</code></p>
        <p>Returns a list of all products</p>
        <p><strong>Response:</strong> 200 OK / 204 No Content</p>
        <h3>2. Get Product By ID</h3>
        <p><code>GET /api/products/{id}</code></p>
        <p>Returns a product by ID</p>
        <p><strong>Response:</strong> 200 OK / 404 Not Found</p>
        <h3>3. Create a Product</h3>
        <p><code>POST /api/products</code></p>
        <p>Creates a new product</p>
        <p><strong>Request Body:</strong> <code>ProductDto</code></p>
        <p><strong>Response:</strong> 201 Created / 400 Bad Request</p>
        <h3>4. Update a Product</h3>
        <p><code>PUT /api/products/{id}</code></p>
        <p>Updates an existing product</p>
        <p><strong>Request Body:</strong> <code>ProductDto</code></p>
        <p><strong>Response:</strong> 200 OK / 404 Not Found / 400 Bad Request</p>
        <h3>5. Delete a Product</h3>
        <p><code>DELETE /api/products/{id}</code></p>
        <p>Deletes a product by ID</p>
        <p><strong>Response:</strong> 204 No Content / 404 Not Found</p>
        <h2>Design Patterns & Best Practices</h2>
        <ul>
            <li><strong>Repository Pattern:</strong> Encapsulates data access logic for better abstraction.</li>
            <li><strong>Service Layer:</strong> Handles business logic and validation.</li>
            <li><strong>DTOs (Data Transfer Objects):</strong> Used to separate API contracts from entity models.</li>
            <li><strong>Dependency Injection:</strong> Ensures loose coupling between components.</li>
        </ul>

        

  <h2>Author</h2>
        <p>Thomas K J</p>
    </div>
</body>
</html>
