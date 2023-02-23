using Microsoft.AspNetCore.Mvc;

namespace Lifetech.WEB.Controllers;

public class NotFoundController : Controller
{
    public IActionResult Index(int code)
    {
        return View();
    }
}