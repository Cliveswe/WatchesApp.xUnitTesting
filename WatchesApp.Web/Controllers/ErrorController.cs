using Microsoft.AspNetCore.Mvc;

namespace WatchesApp.Web.Controllers;
public class ErrorController : Controller
{
    [HttpGet("error/exception")]
    public IActionResult ServerError() {
        return View();
    }

    [HttpGet("/error/http/{HttpStatusCode}")]
    public IActionResult HttpError(int HttpStatusCode) {
        return View(HttpStatusCode);
    }
}
