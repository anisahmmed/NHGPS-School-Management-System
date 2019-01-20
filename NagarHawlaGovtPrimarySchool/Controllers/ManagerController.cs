using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;


namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class ManagerController : Controller
    {
        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public ManagerController(NHGPSContext context)
        {
            _Context = context;
        }


        private void UserNameOnAdminPanel()
        {
            var user = HttpContext.Session.Get("userName");
            string username = System.Text.Encoding.UTF8.GetString(user);
            TempData["userName"] = username;
        }

        //Admin's account type
        private string accountType()
        {
            var account = HttpContext.Session.Get("accountType");
            string accountType = System.Text.Encoding.UTF8.GetString(account);
            return accountType;
        }

        public IActionResult Home()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Admins()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var admins = _Context.Users.Where(u => u.UserID != 1000000).ToList();

                AdminList adminModel = new AdminList
                {
                    AdminAll = admins
                };
                return View(adminModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        //Admin Add
        [HttpGet]
        public IActionResult AdminInformationAdd()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult AdminInformationAdd(User model)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                User adminModel = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    AccountType = model.AccountType
                };

                _Context.Users.Add(adminModel);
                _Context.SaveChanges();

                return RedirectToAction("Admins");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Update code starts from here		
        [HttpGet]
        public IActionResult AdminInformationUpdate(string update)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var admin = _Context.Users.Where(u => u.Email == update).FirstOrDefault();

                User studentModel = new User
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Password = admin.Password,
                    AccountType = admin.AccountType
                };
                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult AdminInformationUpdate(User model, string update)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var admin = _Context.Users.Where(u => u.Email == update).FirstOrDefault();
                _Context.Users.Remove(admin);
                _Context.SaveChanges();

                User adminModel = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    AccountType = model.AccountType
                };

                _Context.Users.Update(adminModel);
                _Context.SaveChanges();

                return RedirectToAction("Admins");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        // Delete code starts from here		
        [HttpGet]
        public IActionResult AdminInformationDelete(string delete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var admin = _Context.Users.Where(u => u.Email == delete).FirstOrDefault();

                User studentModel = new User
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                    Password = admin.Password,
                    AccountType = admin.AccountType
                };
                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public IActionResult AdminInformationDelete(User model, string delete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var admin = _Context.Users.Where(u => u.Email == delete).FirstOrDefault();
                _Context.Users.Remove(admin);
                _Context.SaveChanges();
                return RedirectToAction("Admins");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}