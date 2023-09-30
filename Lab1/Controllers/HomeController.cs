using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers;

public enum Operators
{
    add, mul, sub, div
}

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

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Calculator([FromQuery(Name ="operator")]Operators? op, double? a, double? b)
    {
        if (a == null || b == null)
        {
            return View("Error");
        }
        if (op == null)
        {
            return View("ErrorOp");
        }
        switch (op)
        {
            case Operators.add:
                ViewBag.op = a + b;
                break;
            case Operators.mul:
                ViewBag.op = a * b;
                break;
            case Operators.sub:
                ViewBag.op = a - b;
                break;
            case Operators.div:
                ViewBag.op = a / b;
                break;
        }
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

