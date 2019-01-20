/*
 * All admin and student must login to go admin panale or get result
*/

using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class LoginController : Controller
    {
        private readonly NHGPSContext _Context;

        public LoginController(NHGPSContext context)
        {
            _Context = context;
        }
        private string accountType()
        {
            var account = HttpContext.Session.Get("accountType");
            string accountType = System.Text.Encoding.UTF8.GetString(account);
            return accountType;
        }

        // Login Page
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.Get("userName") != null)
            {
                if (accountType() == ("AdmissionOfficer"))
                {
                    return RedirectToAction("Blank", "Admission");
                }
                else if (accountType() == ("ResultOfficer"))
                {
                    return RedirectToAction("Result", "Result");
                }
                else if (accountType() == ("Manager"))
                {
                    return RedirectToAction("Home", "Manager");
                }
				else if (accountType() == ("Student"))
                {
                    return View();
                }
                else
                {
                    TempData["LoginFailed"] = "অ্যাকাউন্টের ধরন অনুপস্থিত";
                    return View();
                }
            }
            else
            {
                return View();
            }                
        }

        // Login -> Valid user checking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model)
        {
            var user = _Context.Users.Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();
            if (!ModelState.IsValid && user != null)
            {
                //creating session
                string username = user.FirstName + " " + user.LastName;
                string student_id = user.Email;

                HttpContext.Session.SetString("userName", username);
                HttpContext.Session.SetString("accountType", user.AccountType);
                HttpContext.Session.SetString("student_id", student_id);
                HttpContext.Session.Get("userName");

                if (user.AccountType.Equals("AdmissionOfficer"))
                {
                    return RedirectToAction("Blank", "Admission");
                }
                else if (user.AccountType.Equals("ResultOfficer"))
                {
                    return RedirectToAction("Result", "Result");
                }
                else if (user.AccountType.Equals("Manager"))
                {
                    return RedirectToAction("Home", "Manager");
                }
                else if (user.AccountType.Equals("Student"))
                {
                    return RedirectToAction("StudentResult", "StudentResultView", new { student_id = student_id });
                }
                else
                {
                    TempData["LoginFailed"] = "অ্যাকাউন্টের ধরন অনুপস্থিত";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                TempData["LoginFailed"] = "ইমেইল/পাসওয়ার্ডটি ভুল";
                return RedirectToAction("Login");
            }            
        }
        
        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");            
            HttpContext.Session.Remove("accountType");            
            HttpContext.Session.Remove("student_id");            
            return RedirectToAction("Login", "Login");
            
        }

        // Error/ Invalid Search
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

