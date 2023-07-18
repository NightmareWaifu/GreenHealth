using GreenHealthWebsite.Data;
using GreenHealthWebsite.Models.Staff.Pharmacy;
using Microsoft.AspNetCore.Mvc;

namespace GreenHealthWebsite.Controllers.Pharmacy
{
    public class SupplierController : Controller
    {
        private readonly ALLDbContext _context;

        public SupplierController(ALLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier model)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var existingSupplier = _context.Suppliers.Find(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }
            return View(existingSupplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier model)
        {
            if (ModelState.IsValid)
            {
                var existingSupplier = _context.Suppliers.Find(model.SupplierID);
                if (existingSupplier == null)
                {
                    return NotFound();
                }

                existingSupplier.SupplierName = model.SupplierName;
                existingSupplier.SupplierInfo = model.SupplierInfo;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
