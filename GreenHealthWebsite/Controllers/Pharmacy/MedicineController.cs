using GreenHealthWebsite.Data;
using GreenHealthWebsite.Models.Staff.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace GreenHealthWebsite.Controllers.Pharmacy
{
    public class MedicineController : Controller
    {
        private readonly ALLDbContext _context;

        public MedicineController(ALLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var medicines = _context.Medicines.ToList();
            return View(medicines);
        }

        [HttpGet] // Change from [HttpPost] to [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medicine model)
        {
            if (ModelState.IsValid)
            {
                _context.Medicines.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet] // Keep [HttpPost] for Edit action
        public IActionResult Edit(int id)
        {
            var existingModel = _context.Medicines.Find(id);
            if (existingModel == null)
            {
                return NotFound();
            }
            return View(existingModel);
        }

        [HttpPost]
        public IActionResult Edit(Medicine model)
        {
            if (ModelState.IsValid)
            {
                var existingModel = _context.Medicines.Find(model.MedicineID);
                if (existingModel == null)
                {
                    return NotFound();
                }

                // Update properties of the existing model with values from the edited model
                existingModel.Medicine_Name = model.Medicine_Name;
                existingModel.Description = model.Description;
                existingModel.Stock = model.Stock;
                existingModel.Price = model.Price;
                existingModel.Expiry_Date = model.Expiry_Date;
                existingModel.Image = model.Image;
                // Update other properties as needed

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _context.Medicines.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _context.Medicines.Find(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Medicines.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateStock(int medicineId, int orderedStock)
        {
            var medicine = _context.Medicines.Find(medicineId);
            if (medicine != null)
            {
                medicine.Stock += orderedStock;
                _context.SaveChanges();
            }

            // You can return a JSON response or redirect to another action as needed
            return Json(new { success = true });
        }

    }
}
