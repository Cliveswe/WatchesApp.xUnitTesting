# WatchesApp

A MVC web application for managing a collection of watches. Built with ASP.NET Core (.NET 9), this project demonstrates CRUD operations, form validation, and dynamic UI rendering using Razor Pages.

##Note: 
This project is a simplified version of a watch management application and does not include a database. Instead, it uses in-memory data storage for demonstration purposes.
It is designed to showcase the use of Razor Pages, form validation, and responsive design with Bootstrap.
It is not intended for production use or real-world applications.
only the CR (Create and Read) operations are implemented, with a focus on adding watches and displaying them in a list.
This application is in production-ready state for https launch settings and can be used as a starting point for further development.

## Features

- List all watches with details
- Add new watches with brand, model, price, category, release year, image, and description
- Category and year selection with drop-downs
- Server-side and client-side validation
- Responsive design with Bootstrap
- Image URL validation with fall-back to a default image
- Clean separation of concerns using repositories and view models

## Technologies

- .NET 9
- ASP.NET Core Razor Pages
- Entity Framework Core (if used for data access)
- Bootstrap 5
- jQuery & jQuery Validation

## Project Structure

- `WatchesApp.Web/` - Main Razor Pages web project
- `Controllers/` - Handles HTTP requests and prepares view models
- `Models/` - ViewModels and data models for watches and categories
- `Views/` - Razor views for each page
- `wwwroot/` - Static files (CSS, JS, images)

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later

### Running the Application

1. Clone the repository:

2. Restore dependencies:

3. Build and run the project:

4. Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console).

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements and bug fixes.

## License

This project is licensed under the MIT License.


## Solution Structure Update

The solution has been refactored to follow a clearer separation of concerns between service and repository layers. The following changes have been made:

### Clean Clean Architecture Structure and Design
- ## Project Structure

### **WatchesApp.Domain**
- **Entities** (previously called *Models*)
- Represents data
- No dependencies

---

### **WatchesApp.Application**
- Services (business workflows and business logic)
- Interfaces for services and repositories
- Manages data
- Depends on the **Domain** project
<pre><code>### Folder Structure Example 
  Customer/ 
  ├── Services/ 
     └── CustomerService.cs 
  ├── Interfaces/ 
     └── ICustomerService.cs 
  Product/ 
  ├── Services/ 
     └── ProductService.cs 
  ├── Interfaces/ 
     └── IProductService.cs 
   </code></pre>

###
---

### **WatchesApp.Infrastructure**
- Repositories (e.g., Entity Framework implementations — *not yet implemented*)
- Unit of Work classes (*not yet implemented*)
- Coordinates write operations from multiple repositories into a single transaction
- May contain services (technical dependencies only – no business logic)
- Handles data persistence
- Depends on the **Application** project (and indirectly on **Domain**)
<pre><code>### Folder Structure Example 
  Persistence/
  └── Repositories 
  Services/ (optional)
  DependencyInjection/ (optional) </code></pre>
 
---

### **WatchesApp.Presentation**
- Presentation layer, e.g., an MVC application
- Displays data to the user
- Depends on **Infrastructure** (and indirectly on **Application** and **Domain** projects)


### Projects and Key Files

- **Application**
  - `Services/WatchService.cs`  
    Provides business logic and acts as a wrapper around the repository for watch management.
  - `Services/CategoryService.cs`  
    Manages watch categories.

- **Infrastructure**
  - `Repositories/WatchRepository.cs`  
    Handles in-memory storage and retrieval of watch entities. Implements `IWatchRepository`.

- **Domain**
  - `Entities/Watch.cs`  
    Represents the watch entity.
  - `Entities/Category.cs`  
    Represents the category entity.

- **WatchesApp.Web**
  - (Razor Pages, UI, and web entry point)

### Summary of Changes

- The `WatchService` class now delegates data access to `IWatchRepository` and focuses on business logic.
- The `WatchRepository` class is responsible for data persistence and retrieval, and is registered for dependency injection.
- The solution structure now clearly separates application logic (services) from infrastructure concerns (repositories).
