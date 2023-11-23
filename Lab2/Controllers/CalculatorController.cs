using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab2.Controllers
{
    public class CalculatorController : Controller
    {
        

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }

        public IActionResult Form()
        {
            return View();
        }
    }
}

