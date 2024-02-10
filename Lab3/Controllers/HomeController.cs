using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    using Lab3.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeController : Controller
    {
        private static List<ComputerModel> _computers = new List<ComputerModel>();

        public IActionResult Index()
        {
            return View(_computers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ComputerModel computer)
        {
            if (ModelState.IsValid)
            {
                computer.Id = _computers.Any() ? _computers.Max(c => c.Id) + 1 : 1;
                _computers.Add(computer);
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var computer = _computers.FirstOrDefault(c => c.Id == id);
            if (computer == null) return NotFound();
            return View(computer);
        }

        [HttpPost]
        public IActionResult Edit(ComputerModel computer)
        {
            if (ModelState.IsValid)
            {
                var existingComputer = _computers.FirstOrDefault(c => c.Id == computer.Id);
                if (existingComputer == null) return NotFound();

                // Update properties
                existingComputer.Name = computer.Name;
                existingComputer.Processor = computer.Processor;
                existingComputer.Memory = computer.Memory;
                existingComputer.GraphicsCard = computer.GraphicsCard;
                existingComputer.Manufacturer = computer.Manufacturer;
                existingComputer.ProductionDate = computer.ProductionDate;

                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var computer = _computers.FirstOrDefault(c => c.Id == id);
            if (computer == null) return NotFound();
            return View(computer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var computer = _computers.FirstOrDefault(c => c.Id == id);
            if (computer != null)
            {
                _computers.Remove(computer);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var computer = _computers.FirstOrDefault(c => c.Id == id);
            if (computer == null) return NotFound();
            return View(computer);
        }
    }

}
