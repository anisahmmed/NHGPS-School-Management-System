using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class StudentResultViewController : Controller
    {
        private readonly NHGPSContext _Context;

        public StudentResultViewController(NHGPSContext context)
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

        //Admin's account type
        private string studentID()
        {
            var studentId = HttpContext.Session.Get("student_id");
            string studentIds = System.Text.Encoding.UTF8.GetString(studentId);
            return studentIds;
        }

        public IActionResult StudentResult(string student_id, string exam_type)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Student") && studentID().Equals(student_id))
            {
                //showing user name on admin pannel                
                UserNameOnAdminPanel();
                if (exam_type == null)
                {
                    var firstTerm = _Context.RelResults.Where(u => u.student_id == "10000000").ToList();

                    RelResultList resultModel = new RelResultList
                    {
                        RelResultAll = firstTerm
                    };
                    ViewData["student_id"] = student_id;
                    return View(resultModel);
                }
                else
                {
                    var firstTerm = _Context.RelResults.Where(u => u.student_id== student_id &&  u.exam_type == exam_type).ToList();

                    RelResultList resultModel = new RelResultList
                    {
                        RelResultAll = firstTerm
                    };
                    ViewData["student_id"] = student_id;
                    return View(resultModel);
                }              

                
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        
    }
}