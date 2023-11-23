using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthLab2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthLab2.Controllers
{
    public class BirthController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Birth model)
        {
            if (!model.isValid())
            {
                int age = model.CalculateAge();
                return View("Result", new { Name = model.Name, Age = age });
            }
            else
            {
                return View("Error");
            }
        }
    }
}

