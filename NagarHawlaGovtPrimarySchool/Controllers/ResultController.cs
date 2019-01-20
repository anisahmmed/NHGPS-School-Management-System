/* 
 * ResultOfficer
  * ফলাফল  পেইজ
 * This is for inputing result for each student
 * Edit, delete, update results
*/

using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;

namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class ResultController : Controller
    {
        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public ResultController(NHGPSContext context)
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

        // ফলাফল -> Exam Type
        [HttpGet]
        public IActionResult Result()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel                
                UserNameOnAdminPanel();
                var examTypes = _Context.ExamTypes.Where(u => u.exam_id != 1000000).ToList();
                ExamTypeList examTypemodel = new ExamTypeList
                {
                    ExamTypeAll = examTypes
                };
                return View(examTypemodel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // ফলাফল -> Exam Type -> Class List
        [HttpGet]
        public IActionResult ResultClass(string exam_type)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel                
                UserNameOnAdminPanel();
                var classes = _Context.Classes.Where(u => u.class_id != 1000000).ToList();
                ClassList classmodel = new ClassList
                {
                    ClassAll = classes
                };
				ViewData["exam_type"] = exam_type;
                return View(classmodel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // ফলাফল -> Exam Type -> Class List -> Section List
        public IActionResult SectionSearchByClass(string className, string exam_type)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var sectionName = _Context.RelClassSections.Where(u => u.class_name == className).ToList();

                RelClassSectionList sectionModel = new RelClassSectionList
                {
                    SectionAll = sectionName
                };
				
				ViewData["exam_type"] = exam_type;
                return View(sectionModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // ফলাফল -> Exam Type -> Class List -> Section List -> Student List for specific class,section
        [HttpGet]
        public IActionResult StudentSearchByClass(string className, string sectionName, string exam_type)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                var students = _Context.Students.Where(u => u.ClassName == className && u.Section == sectionName).ToList();

                StudentList studentModel = new StudentList
                {
                    StudentAll = students
                };
				ViewData["exam_type"] = exam_type;
				ViewData["sectionName"] = sectionName;
                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // ফলাফল -> Exam Type -> Class List -> Section List -> Student List - Input marks
        public IActionResult StudentResultIndividualUpdate(string StudentId, string ClassName, string exam_type, string sectionName)
        {
			if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
                 var studentResult = _Context.RelClassSubjects.Where(u => u.class_name == ClassName).ToList();

                RelClassSubjectList relClass = new RelClassSubjectList
				{
					RelClassSubjectAll = studentResult
				};

				ViewData["studentId"] = StudentId;
				ViewData["className"] = ClassName;
				ViewData["exam_type"] = exam_type;
				ViewData["sectionName"] = sectionName;
				return View(relClass);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
                       
        }

        // ফলাফল -> Exam Type -> Class List -> Section List -> Student List - add/update reslt
        [HttpPost]
        public IActionResult StudentResultIndividualUpdate( RelResult model)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("ResultOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();
				var availableResult = _Context.RelResults.Where(u=> u.student_id == model.student_id && u.exam_type == model.exam_type && u.subject_name == model.subject_name).FirstOrDefault();
				if(availableResult != null)
				{
					_Context.RelResults.Remove(availableResult);
					_Context.SaveChanges();
					
					RelResult admit = new Models.RelResult()
					{
					student_id = model.student_id,
					class_name = model.class_name,
					section = model.section,
					exam_type = model.exam_type,
					subject_name = model.subject_name,
					marks = model.marks
					};             

					_Context.RelResults.Update(admit);
					_Context.SaveChanges();
				}
				else
				{
					RelResult admit = new Models.RelResult()
					{
                    student_id = model.student_id,
                    class_name = model.class_name,
                    section = model.section,
                    exam_type = model.exam_type,
                    subject_name = model.subject_name,
                    marks = model.marks
					};              

					_Context.RelResults.Add(admit);
					_Context.SaveChanges();
				}
                
                return RedirectToAction("StudentResultIndividualUpdate", new { StudentId = model.student_id, ClassName = model.class_name, exam_type = model.exam_type, sectionName = model.section });
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
