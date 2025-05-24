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
