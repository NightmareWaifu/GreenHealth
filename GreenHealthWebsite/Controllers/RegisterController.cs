using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenHealthWebsite.Data;
using GreenHealthWebsite.Models.Admin;

namespace GreenHealthWebsite.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ALLDbContext _context;

        public RegisterController(ALLDbContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
              return _context.CustomerAccounts != null ? 
                          View(await _context.CustomerAccounts.ToListAsync()) :
                          Problem("Entity set 'ALLDbContext.CustomerAccounts'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CustomerAccounts == null)
            {
                return NotFound();
            }

            var patientAccounts = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.NRIC == id);
            if (patientAccounts == null)
            {
                return NotFound();
            }

            return View(patientAccounts);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NRIC,Name,Password,Gender,Roles,PhoneNum,Email,DOB,DOD,Address")] PatientAccounts patientAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientAccounts);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CustomerAccounts == null)
            {
                return NotFound();
            }

            var patientAccounts = await _context.CustomerAccounts.FindAsync(id);
            if (patientAccounts == null)
            {
                return NotFound();
            }
            return View(patientAccounts);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NRIC,Name,Password,Gender,Roles,PhoneNum,Email,DOB,DOD,Address")] PatientAccounts patientAccounts)
        {
            if (id != patientAccounts.NRIC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientAccountsExists(patientAccounts.NRIC))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patientAccounts);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CustomerAccounts == null)
            {
                return NotFound();
            }

            var patientAccounts = await _context.CustomerAccounts
                .FirstOrDefaultAsync(m => m.NRIC == id);
            if (patientAccounts == null)
            {
                return NotFound();
            }

            return View(patientAccounts);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CustomerAccounts == null)
            {
                return Problem("Entity set 'ALLDbContext.CustomerAccounts'  is null.");
            }
            var patientAccounts = await _context.CustomerAccounts.FindAsync(id);
            if (patientAccounts != null)
            {
                _context.CustomerAccounts.Remove(patientAccounts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientAccountsExists(string id)
        {
          return (_context.CustomerAccounts?.Any(e => e.NRIC == id)).GetValueOrDefault();
        }
    }
}
