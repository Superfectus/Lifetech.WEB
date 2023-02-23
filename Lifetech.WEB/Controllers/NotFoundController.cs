using Microsoft.AspNetCore.Mvc;

namespace Lifetech.Controllers;

public class NotFoundController : Controller
{
    public IActionResult Index(int code)
    {
        return View();
    }
}