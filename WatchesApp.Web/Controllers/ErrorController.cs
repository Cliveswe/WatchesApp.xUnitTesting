// -----------------------------------------------------------------------------
// File: ErrorController.cs
// Summary: Handles server-side and HTTP status code errors by rendering
//          appropriate error views. Central point for error handling logic.
// <author> [Clive Leddy] </author>
// <created> [2025-05-23] </created>
// Notes: Includes routes for generic server errors and HTTP status code-specific
//        error pages (e.g., 404, 500). Keeps error response handling organized.
// -----------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

namespace WatchesApp.Web.Controllers;

/// <summary>
/// Provides actions for handling and displaying error pages in response to server-side exceptions and HTTP error status
/// codes.
/// </summary>
/// <remarks>This controller is used to centralize error handling in the application. It includes actions for
/// rendering a generic server error page and for displaying views corresponding to specific HTTP status codes. These
/// actions are typically invoked when exceptions or HTTP errors occur during request processing.</remarks>
public class ErrorController : Controller
{
    /// <summary>
    /// Returns a view that represents a server error.
    /// </summary>
    /// <remarks>This action method is typically used to display a generic error page for server-side
    /// exceptions.</remarks>
    /// <returns>An <see cref="IActionResult"/> that renders the server error view.</returns>
    [HttpGet("error/exception")]
    public IActionResult ServerError() {
        return View();
    }

    /// <summary>
    /// Handles HTTP error responses by returning a view corresponding to the specified HTTP status code.
    /// </summary>
    /// <param name="HttpStatusCode">The HTTP status code representing the error to display. Must be a valid HTTP status code.</param>
    /// <returns>An <see cref="IActionResult"/> that renders a view for the specified HTTP status code.</returns>
    [HttpGet("/error/http/{HttpStatusCode}")]
    public IActionResult HttpError(int HttpStatusCode) {
        return View(HttpStatusCode);
    }
}
