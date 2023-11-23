using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;

namespace Lab3.Controllers;

public class KomputerController : Controller
{
    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Create(Komputer komputer)
    {
        if (ModelState.IsValid)
        {

        }
        else
        {
            return Viev();
        }
    }
}

