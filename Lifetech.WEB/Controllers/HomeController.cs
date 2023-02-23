using System.Diagnostics;
using Lifetech.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lifetech.WEB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [Route("/outsource", Name = "Outsource")]
    public IActionResult Outsource()
    {
        return View();
    }
    
    [Route("/testoutsource", Name = "TestOutsource")]
    public IActionResult TestOutsource()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}