/*
 * Result Officer
 * This is for watching result for all student
 * Result officer will see results
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class AdminStudentResultViewController : Controller
    {
        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public AdminStudentResultViewController(NHGPSContext context)
        {
            _Context = context;
        }

        //Admin Full name
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

        //AdminStudentResultViewController -> Classes
        public IActionResult Classes()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var classes = _Context.Classes.Where(u => u.class_id != 100000).ToList();
                ClassList classModel = new ClassList
                {
                    ClassAll = classes
                };
                return View(classModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
		
		//AdminStudentResultViewController -> Classes -> Sections
        public IActionResult Sections(string ClassName)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var sections = _Context.RelClassSections.Where(u => u.class_name == ClassName).ToList();
                RelClassSectionList sectionsModel = new RelClassSectionList
                {
                   SectionAll = sections
                };
                return View(sectionsModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
		
		//AdminStudentResultViewController -> Classes -> Sections -> StudentList
        public IActionResult StudentList(string className, string sectionName)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var students = _Context.Students.Where(u => u.ClassName == className && u.Section == sectionName).ToList();
                StudentList studentsModel = new StudentList
                {
                   StudentAll = students
                };
                return View(studentsModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
		
		//AdminStudentResultViewController -> Classes -> Sections -> StudentList -> StudentResultIndividual
        public IActionResult StudentResultIndividual(string studentId, string className, string sectionName)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var studentResult = _Context.RelResults.Where(u => u.student_id == studentId).ToList();
				
                RelResultList studentResultModel = new RelResultList
                {
                   RelResultAll = studentResult
                };
                return View(studentResultModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        
    }
}
