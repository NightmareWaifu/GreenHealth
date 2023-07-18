using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using GreenHealthWebsite.Models.Admin;
using GreenHealthWebsite.Models.Login;

namespace GreenHealthWebsite.Controllers
{
    public class LoginController : Controller
    {
        //SqlConnection connect = new SqlConnection();
        //SqlCommand command = new SqlCommand();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(PatientAccounts PatientEmail, StaffAccounts StaffEmail)
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Submit(PatientAccounts account)
        //{
        //    //return Redirect("/CustomerAppointment/Index");
        //    return Redirect("/Login/CustomerPage");
        //}

        //[HttpPost]
        //public IActionResult Submit(LoginView model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // Check if the entered credentials exist in the Patients table
        //    var patient = CheckPatientCredentials(model.Email, model.Password);
        //    if (patient != null)
        //    {
        //        // Authenticate the patient and proceed with the patient workflow
        //        // For example, you can store the patient's ID in a session variable
        //        Session["PatientId"] = patient.Id;
        //        return RedirectToAction("PatientDashboard", "Home");
        //    }

        //    // Check if the entered credentials exist in the Staff table
        //    var staff = CheckStaffCredentials(model.Username, model.Password);
        //    if (staff != null)
        //    {
        //        // Authenticate the staff member and proceed with the staff workflow
        //        // For example, you can store the staff's ID in a session variable
        //        Session["StaffId"] = staff.Id;
        //        return RedirectToAction("StaffDashboard", "Home");
        //    }

        //    // If no match found in either table, display an error message
        //    ModelState.AddModelError("", "Invalid login credentials.");
        //    return View(model);
        //    //return Redirect("/CustomerAppointment/Index");
        //    //return Redirect("/Login/CustomerPage");
            
        //}

        //// Helper method to check patient credentials
        //private PatientAccounts CheckPatientCredentials(string email, string password)
        //{
        //    using (var db = new connectionString())
        //    {
        //        return db.PatientAccounts.FirstOrDefault(p => p.Email == email && p.Password == password);
        //    }
        //}

        //// Helper method to check staff credentials
        //private StaffAccounts CheckStaffCredentials(string email, string password)
        //{
        //    using (var db = new YourDbContext())
        //    {
        //        return db.StaffAccounts.FirstOrDefault(s => s.Username == email && s.Password == password);
        //    }
        //}

        [HttpGet]
        public IActionResult CustomerPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoctorPage()
        {
            return View();
        }

        //public IActionResult PharmacistPage()
        //{
        //    return View();
        //}

        //public IActionResult AdminPage()
        //{
        //    return View();
        //}
    }
}
