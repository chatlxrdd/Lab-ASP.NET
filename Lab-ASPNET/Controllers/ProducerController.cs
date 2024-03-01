using Lab_ASPNET.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Lab_ASPNET.Services.Producery;


namespace Lab_ASPNET.Controllers
{
    public class ProducerController : Controller
    {
        private static Dictionary<int, Producer> _producers = new Dictionary<int, Producer>();

        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }
        public IActionResult Index()
        {
            var Producers = _producerService.Find();
            return View(Producers);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Producer model = new Producer();
            model.Producers = _producerService
                .FindAllProducents()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Producer model)
        {
            if (ModelState.IsValid)
            {
                _producerService.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                model.Producers = _producerService
                    .FindAllProducents()
                    .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                    .ToList();
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var producer = _producerService.FindProducerById(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }

        [HttpPost]
        public IActionResult Edit(Producer model)
        {
            if (ModelState.IsValid)
            {
                _producerService.Update(model);
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
            var producer = _producerService.FindProducerById(id);
            if (producer == null)
            {
                return NotFound();
            }
            return View(producer);
        }
    }
}