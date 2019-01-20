/* 
  * Manager
  * সম্পাদন করুন  পেইজ
 * This is for Editing a specific class infromation.
 * We can add delete Sections and Subjects for a specific class.
 * We can add ExamType  also
*/

using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class EditController : Controller
    {
        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public EditController(NHGPSContext context)
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

        // Manager edit page
        public IActionResult EditPage()
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

        // Manager edit -> Class
        public IActionResult Classs()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var className = _Context.Classes.Where(u => u.class_id != 100).ToList();
                ClassList classModel = new ClassList
                {
                    ClassAll = className
                };
                return View(classModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Class - update
        public IActionResult ClassUpdate(Class model, string classNameUpdate)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var classes = _Context.Classes.Where(u => u.class_name == model.class_name).FirstOrDefault();
                _Context.Classes.Remove(classes);
                _Context.SaveChanges();

                Class classModel = new Class
                {
                    class_name = classNameUpdate
                };
                _Context.Classes.Update(classModel);
                _Context.SaveChanges();

                return RedirectToAction("Classs");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Class - add 
        public IActionResult ClassAdd(string classNameAdd)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                Class classModel = new Class
                {
                    class_name = classNameAdd
                };
                _Context.Classes.Add(classModel);
                _Context.SaveChanges();

                return RedirectToAction("Classs");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        // Manager edit -> Class - delete
        public IActionResult ClassDelete(string classNameDelete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var classes = _Context.Classes.Where(u => u.class_name == classNameDelete).FirstOrDefault();
                _Context.Classes.Remove(classes);
                _Context.SaveChanges();
                return RedirectToAction("Classs");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Class -> Ok button
		/*
			Whenever OK button will click it will redirect manager to " RelClass " controller and " RelClasses " action,
			to do rest of the work.		
		*/
        public IActionResult ClassOkButton(string className)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                return RedirectToAction("RelClasses", "RelClass", new { className = className });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Sections
        public IActionResult Sections()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var sectionName = _Context.Sections.Where(u => u.sec_id != 100).ToList();
                SectionList sectionModel = new SectionList
                {
                    SectionAll = sectionName
                };
                return View(sectionModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // // Manager edit -> Sections - update
        public IActionResult SectionUpdate(Section model, string sectionNameUpdate)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var sections = _Context.Sections.Where(u => u.section == model.section).FirstOrDefault();
                _Context.Sections.Remove(sections);
                _Context.SaveChanges();

                Section sectionModel = new Section
                {
                    section = sectionNameUpdate
                };
                _Context.Sections.Update(sectionModel);
                _Context.SaveChanges();

                return RedirectToAction("Sections");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Sections - Add 
        public IActionResult SectionAdd(string sectionNameAdd)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                Section sectionModel = new Section
                {
                    section = sectionNameAdd
                };
                _Context.Sections.Add(sectionModel);
                _Context.SaveChanges();

                return RedirectToAction("Sections");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        // Manager edit -> Sections - Delete
        public IActionResult SectionDelete(string sectionNameDelete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var sections = _Context.Sections.Where(u => u.section == sectionNameDelete).FirstOrDefault();
                _Context.Sections.Remove(sections);
                _Context.SaveChanges();
                return RedirectToAction("Sections");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Subject 
        public IActionResult Subjects()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var subjectName = _Context.Subjects.Where(u => u.sub_id != 100).ToList();
                SubjectList subjectModel = new SubjectList
                {
                    SubjectAll = subjectName
                };
                return View(subjectModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Subject - Add
        public IActionResult SubjectAdd(string subjectNameAdd)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                Subject subjectModel = new Subject
                {
                    sub_name = subjectNameAdd
                };
                _Context.Subjects.Add(subjectModel);
                _Context.SaveChanges();

                return RedirectToAction("Subjects");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        // Manager edit -> Subject - Delete 
        public IActionResult SubjectDelete(string subjectNameDelete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var subject = _Context.Subjects.Where(u => u.sub_name == subjectNameDelete).FirstOrDefault();
                _Context.Subjects.Remove(subject);
                _Context.SaveChanges();
                return RedirectToAction("Subjects");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Exam Type
        public IActionResult ExamTypes()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var examType = _Context.ExamTypes.Where(u => u.exam_id != 100).ToList();
                ExamTypeList examTypeModel = new ExamTypeList
                {
                    ExamTypeAll = examType
                };
                return View(examTypeModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Exam Type - update
        public IActionResult ExamTypeUpdate(ExamType model, string examTypeUpdate)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var examTypes = _Context.ExamTypes.Where(u => u.exam_type == model.exam_type).FirstOrDefault();
                _Context.ExamTypes.Remove(examTypes);
                _Context.SaveChanges();

                ExamType examTypeModel = new ExamType
                {
                    exam_type = examTypeUpdate
                };
                _Context.ExamTypes.Update(examTypeModel);
                _Context.SaveChanges();

                return RedirectToAction("ExamTypes");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // Manager edit -> Exam Type - Add
        public IActionResult ExamTypeAdd(string examTypeAdd)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                ExamType examTypeModel = new ExamType
                {
                    exam_type = examTypeAdd
                };
                _Context.ExamTypes.Add(examTypeModel);
                _Context.SaveChanges();

                return RedirectToAction("ExamTypes");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        // Manager edit -> Exam Type - Delete
        public IActionResult ExamTypeDelete(string examTypeDelete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("Manager"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var examTypes = _Context.ExamTypes.Where(u => u.exam_type == examTypeDelete).FirstOrDefault();
                _Context.ExamTypes.Remove(examTypes);
                _Context.SaveChanges();
                return RedirectToAction("ExamTypes");
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
