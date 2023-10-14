using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab2.Controllers
{
    public class CalculatorController : Controller
    {
        public enum Operators
        {
            add,sub,div,mul
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result([FromQuery(Name = "operator")] Operators? op, double? a, double? b)
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

        public IActionResult Form()
        {
            return View();
        }
    }
}

