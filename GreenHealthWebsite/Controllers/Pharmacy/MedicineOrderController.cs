using GreenHealthWebsite.Models.Staff.Pharmacy;
using GreenHealthWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GreenHealthWebsite.Controllers.Pharmacy
{
    public class MedicineOrderController : Controller
    {
        private readonly ALLDbContext _context;

        public MedicineOrderController(ALLDbContext context)
        {
            _context = context;
        }

        public IActionResult ViewOrder()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Order()
        {
            ViewBag.Medicines = _context.Medicines.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Order(MedicineOrder model)
        {
            var medicine = _context.Medicines.Find(model.MedicineID);
            var supplier = _context.Suppliers.Find(model.SupplierID);

            if (medicine == null || supplier == null)
            {
                return NotFound();
            }

            var order = new MedicineOrder
            {
                MedicineID = model.MedicineID,
                Medicine_Name = medicine.Medicine_Name,
                SupplierID = model.SupplierID,
                SupplierName = supplier.SupplierName,
                OrderedDate = model.OrderedDate,
                OrderedStock = model.OrderedStock
            };

            _context.MedicineOrders.Add(order);
            _context.SaveChanges();

            UpdateMedicineStock(model.MedicineID, model.OrderedStock);

            // Redirect to the ViewOrders action after successful submission
            return RedirectToAction("ViewOrder");

        }
            public IActionResult ViewOrders()
        {
            var orders = _context.MedicineOrders
                .Include(o => o.Medicines)
                .Include(o => o.Suppliers)
                .ToList();

            return View(orders);
        }
        private void UpdateMedicineStock(int medicineId, int orderedStock)
        {
            var medicine = _context.Medicines.Find(medicineId);
            if (medicine != null)
            {
                medicine.Stock += orderedStock;
                _context.SaveChanges();
            }
        }
    }
}
