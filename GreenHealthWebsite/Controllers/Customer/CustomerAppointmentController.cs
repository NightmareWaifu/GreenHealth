using GreenHealthWebsite.Data;
using GreenHealthWebsite.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenHealthWebsite.Controllers.Customer
{
    public class CustomerAppointmentController : Controller
    {
        private readonly ALLDbContext _context;

        public CustomerAppointmentController(ALLDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var appointmentmade = _context.CustomerAppointment.ToList();
            return View(appointmentmade);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerAppointment Info)
        {
            //Info.AppointmentID = _context.CustomerAppointment.Select(x => x.AppointmentID).FirstOrDefault() + 1;
            //Info.AppointmentID = Guid.NewGuid();
            _context.CustomerAppointment.Add(Info);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect("/CustomerAppointment/Index");

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var Info = _context.CustomerAppointment.Find(id);
            return View(Info);
        }

        [HttpPost]
        public IActionResult Edit(CustomerAppointment Info)
        {
            _context.CustomerAppointment.Update(Info);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect("/CustomerAppointment/Index");
        }

        public IActionResult Delete(Guid? id)
        {
            var Info = _context.CustomerAppointment.Find(id);
            if (Info == null)
            {
                return NotFound();
            }
            return View(Info);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var Info = _context.CustomerAppointment.Find(id);
            _context.CustomerAppointment.Remove(Info);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            return Redirect("/CustomerAppointment/Index");
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var dl = _context.CustomerAppointment.Find(id);
            return View(dl);
        }
    }
}
