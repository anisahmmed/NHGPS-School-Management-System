using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class RelClassController : Controller
    {

        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public RelClassController(NHGPSContext context)
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

        public IActionResult RelClasses(string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var subjectAvailable = _Context.RelClassSubjects.Where(u => u.class_name == className).ToList();
                var sectionAvailable = _Context.RelClassSections.Where(v => v.class_name == className).ToList();
                var subjects = _Context.Subjects.Where(w => w.sub_id != 100).ToList();
                var sections = _Context.Sections.Where(x => x.sec_id != 100).ToList();

                RelClass relClass = new RelClass
                {
                    SubjectAll = subjectAvailable,
                    SectionAll = sectionAvailable,
                    SubjectList = subjects,
                    SectionList = sections
                };
                return View(relClass);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Subject Add
        public IActionResult SubjectAdd(string SubjectNameAdd, string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                RelClassSubject subjectModel = new RelClassSubject
                {
                    class_name = className,
                    subject_name = SubjectNameAdd
                };

                _Context.RelClassSubjects.Add(subjectModel);
                _Context.SaveChanges();

                return RedirectToAction("RelClasses", new { className = className });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Subject delete code starts from here 
        public IActionResult SubjectDelete(string subjectNameDelete, string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var subjects = _Context.RelClassSubjects.Where(u => u.subject_name == subjectNameDelete && u.class_name == className).FirstOrDefault();
                _Context.RelClassSubjects.Remove(subjects);
                _Context.SaveChanges();
                return RedirectToAction("RelClasses", new { className = className });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Section Add
        public IActionResult SectionAdd(string sectionNameAdd, string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                RelClassSection sectionModel = new RelClassSection
                {
                    class_name = className,
                    section_name = sectionNameAdd
                };
                _Context.RelClassSections.Add(sectionModel);
                _Context.SaveChanges();

                return RedirectToAction("RelClasses", new { className = className });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Section delete code starts from here 
        public IActionResult SectionDelete(string sectionNameDelete, string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var sections = _Context.RelClassSections.Where(u => u.section_name == sectionNameDelete && u.class_name == className).FirstOrDefault();
                _Context.RelClassSections.Remove(sections);
                _Context.SaveChanges();

                return RedirectToAction("RelClasses", new { className = className });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
