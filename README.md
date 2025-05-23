# WatchesApp

A Razor Pages web application for managing a collection of watches. Built with ASP.NET Core (.NET 9), this project demonstrates CR (just create and read from CRUD) operations, form validation, and dynamic UI rendering using Razor Pages.

## Features

- List all watches with details
- Add new watches with brand, model, price, category, release year, image, and description
- Edit and delete existing watches
- Category and year selection with dropdowns
- Server-side and client-side validation
- Responsive design with Bootstrap

## Technologies

- .NET 9
- ASP.NET Core Razor Pages
- Entity Framework Core (if used for data access)
- Bootstrap 5
- jQuery & jQuery Validation

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 or later

### Running the Application

1. Clone the repository:

2. Restore dependencies:

3. Build and run the project:

4. Open your browser and navigate to `https://localhost:5001` (or the URL shown in the console).

### Project Structure

- `WatchesApp.Web/` - Main Razor Pages web project
- `Views/` - Razor views for each page
- `Models/` - ViewModels and data models
- `wwwroot/` - Static files (CSS, JS, images)

## Contributing

Contributions are welcome! Please open issues or submit pull requests for improvements and bug fixes.

## License

This project is licensed under the MIT License.
