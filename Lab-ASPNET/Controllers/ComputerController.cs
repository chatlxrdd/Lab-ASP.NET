using Lab_ASPNET.Models;
using Lab_ASPNET.Services.Computery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Lab_ASPNET.Controllers
{
    [Authorize(Roles = "admin")]
    public class ComputerController : Controller
    {
        private static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();

        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }
        public IActionResult Index()
        {
            var Computers = _computerService.Find();
            return View(Computers);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _computerService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Computer model = new Computer();
            model.Producers = _computerService
                .FindAllProducents()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computerService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                model.Producers = _computerService
                    .FindAllProducents()
                    .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                    .ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Computer = _computerService.FindComputerById(id);
            if (Computer == null)
            {
                return NotFound();
            }
            return View(Computer);
        }

        [HttpPost]
        public IActionResult Edit(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computerService.Update(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var Computer = _computerService.FindComputerById(id);
            if (Computer == null)
            {
                return NotFound();
            }
            return View(Computer);
        }

    }
}
