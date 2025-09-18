# Product API 🐳

A simple, yet robust, RESTful API for managing product data. This project showcases a modern approach to application deployment and environment setup using **Docker**.

### Technical Stack & Containerization

This project demonstrates how to create a complete, self-contained development environment using containers.

* **Containerization**: The entire application, including the API and its database, is managed with **Docker** and orchestrated with a **`docker-compose.yml`** file. This setup provides a portable and reproducible environment, allowing you to get the application up and running instantly with a single command, regardless of your local machine's configuration. This is the core strength of this project.
* **API Framework**: Developed using **ASP.NET Core Minimal APIs** on **.NET 8**, focusing on performance and a clean, concise syntax for building HTTP endpoints.
* **Data Layer**: **Entity Framework Core 8** is used for data persistence. It implements the **Repository Pattern** to abstract data access logic and ensure separation of concerns.
* **Database**: The application is configured to use **MySQL** as its relational database.

---

### Key Features

* **Fully Containerized Environment**: The entire system runs as two interconnected Docker containers (one for the API, one for the database).
* **Full CRUD Functionality**: The API provides endpoints to create, read, update, and delete product data.
* **Dependency Injection**: Services like the `IProductRepository` and `AppDbContext` are managed through .NET's built-in dependency injection system.
* **Automated Database Migration**: The application automatically applies Entity Framework migrations on startup to ensure the database schema is up-to-date.
* **Health Check**: A dedicated health check endpoint confirms the service is running correctly.

---

### Getting Started

To run this project, you need to have Docker installed on your machine.

1.  **Clone the repository:**
    ```sh
    git clone [repository-url]
    cd [repository-name]
    ```

2.  **Start the containers:**
    The `docker-compose.yml` file will build the API image, pull the MySQL image, and set up the network.
    ```sh
    docker-compose up --build
    ```
3.  **Access the API**:
    Once the containers are up and running, you can access the API at `http://localhost:8080`.
    * **Health Check**: `http://localhost:8080/api/health`

---

### API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/products` | Retrieves a list of all products. |
| `GET` | `/api/products/{id}` | Retrieves a single product by its ID. |
| `POST` | `/api/products` | Creates a new product. |
| `PUT` | `/api/products/{id}` | Updates an existing product. |
| `DELETE` | `/api/products/{id}` | Deletes a product by its ID. |
