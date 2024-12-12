using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cafeteria.Models;
using Microsoft.Extensions.Localization;

namespace Cafeteria.Controllers;

public class HomeController : Controller
{   
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;

    public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
    {
        _logger = logger;
        _localizer = localizer;
    }

    public IActionResult Index()
    {
        ViewData["GreetingMessage"] = _localizer["GreetingMessage"];
        ViewData["Title"] = _localizer["HomeTitle"];
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
