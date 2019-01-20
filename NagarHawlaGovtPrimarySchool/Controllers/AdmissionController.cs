/*
 * Admission Officer
 * This is for Admitting student
 * Student information can edit, view, delete by this controller
*/

using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NagarHawlaGovtPrimarySchool.Models;


namespace NagarHawlaGovtPrimarySchool.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly NHGPSContext _Context;

        //Constructor to get the database at the beginning
        public AdmissionController(NHGPSContext context)
        {
            _Context = context;
        }

        // Admin's Full Name
        private void UserNameOnAdminPanel() {
            var user = HttpContext.Session.Get("userName");
            string username = System.Text.Encoding.UTF8.GetString(user);
            TempData["userName"] = username;
        }

        // Admin's Acount Type
        private string accountType()
        {
            var account = HttpContext.Session.Get("accountType");
            string accountType = System.Text.Encoding.UTF8.GetString(account);
            return accountType;
        }

        // Blank Page for admin panel
        public IActionResult Blank()
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
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
        
        // Vorti form
        [HttpGet]
        public IActionResult Admission()
        {        
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel                
				UserNameOnAdminPanel();
                var classes = _Context.Classes.Where(u => u.class_id != 10000).ToList();
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

        // Student Admit
        [HttpPost]
        public IActionResult Admission(Admission model)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                Admission admit = new Models.Admission()
                {
                    FormNo = model.FormNo,
                    StudentId = model.StudentId,
                    ClassName = model.ClassName,
                    Section = model.Section,
                    StudentNameBangla = model.StudentNameBangla,
                    StudentNameEnglish = model.StudentNameEnglish,
                    FatherName = model.FatherName,
                    FatherNID = model.FatherNID,
                    FatherMobile = model.FatherMobile,
                    FatherDOB = model.FatherDOB,
                    PaternalGrandFatherName = model.PaternalGrandFatherName,
                    PaternalGrandMotherName = model.PaternalGrandMotherName,
                    MotherName = model.MotherName,
                    MotherNID = model.MotherNID,
                    MotherMobile = model.MotherMobile,
                    MotherDOB = model.MotherDOB,
                    MaternalGrandFatherName = model.MaternalGrandFatherName,
                    MaternalGrandMotherName = model.MaternalGrandMotherName,
                    StudentDOB = model.StudentDOB,
                    StudentBirthCertificateNo = model.StudentBirthCertificateNo,
                    PermanentVillage = model.PermanentVillage,
                    PermanentPost = model.PermanentPost,
                    PermanentPostCode = model.PermanentPostCode,
                    PermanentSubDistrict = model.PermanentSubDistrict,
                    PermanentDistrict = model.PermanentDistrict,
                    PresentVillage = model.PresentVillage,
                    PresentPost = model.PresentPost,
                    PresentPostCode = model.PresentPostCode,
                    PresentSubDistrict = model.PresentSubDistrict,
                    PresentDistrict = model.PresentDistrict,
                    HomeOwnerName = model.HomeOwnerName,
                    HomeOwnerMobile = model.HomeOwnerMobile,
                };

                _Context.Students.Add(admit);
                _Context.SaveChanges();
                return RedirectToAction("Admission");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }
		
        // Search Student using class
		public IActionResult SearchStudentInformation(){
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
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
		
        // Sikkharthider tottho -> Class wise
		[HttpGet]
		public IActionResult StudentSearchByClass(string ClassName){
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();				
                var students = _Context.Students.Where(u => u.ClassName == ClassName).ToList();

                StudentList studentModel = new StudentList
                {
                    StudentAll = students
                };

                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
		}

        // Sikkharthider tottho -> Class wise -> Single Student       
        public IActionResult StudentInformationIndividual(int detail){
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var students = _Context.Students.Where(u => u.StudentId == detail).FirstOrDefault();
                Admission studentModel = new Admission
                {
                    StudentId = students.StudentId,
                    ClassName = students.ClassName,
                    Section = students.Section,
                    StudentNameBangla = students.StudentNameBangla,
                    StudentNameEnglish = students.StudentNameEnglish,
                    FatherName = students.FatherName,
                    FatherNID = students.FatherNID,
                    FatherMobile = students.FatherMobile,
                    FatherDOB = students.FatherDOB,
                    PaternalGrandFatherName = students.PaternalGrandFatherName,
                    PaternalGrandMotherName = students.PaternalGrandMotherName,
                    MotherName = students.MotherName,
                    MotherNID = students.MotherNID,
                    MotherMobile = students.MotherMobile,
                    MotherDOB = students.MotherDOB,
                    MaternalGrandFatherName = students.MaternalGrandFatherName,
                    MaternalGrandMotherName = students.MaternalGrandMotherName,
                    StudentDOB = students.StudentDOB,
                    StudentBirthCertificateNo = students.StudentBirthCertificateNo,
                    PermanentVillage = students.PermanentVillage,
                    PermanentPost = students.PermanentPost,
                    PermanentPostCode = students.PermanentPostCode,
                    PermanentSubDistrict = students.PermanentSubDistrict,
                    PermanentDistrict = students.PermanentDistrict,
                    PresentVillage = students.PresentVillage,
                    PresentPost = students.PresentPost,
                    PresentPostCode = students.PresentPostCode,
                    PresentSubDistrict = students.PresentSubDistrict,
                    PresentDistrict = students.PresentDistrict,
                    HomeOwnerName = students.HomeOwnerName,
                    HomeOwnerMobile = students.HomeOwnerMobile,
                };
            
                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
		}

        // Sikkharthider tottho -> Class wise -> Individual Update view 		
        [HttpGet]
		public IActionResult StudentInformationIndividualUpdate(int update){
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var students = _Context.Students.Where(u => u.StudentId == update).FirstOrDefault();

                Admission studentModel = new Admission
                {
                    StudentId = students.StudentId,
                    ClassName = students.ClassName,
                    Section = students.Section,
                    StudentNameBangla = students.StudentNameBangla,
                    StudentNameEnglish = students.StudentNameEnglish,
                    FatherName = students.FatherName,
                    FatherNID = students.FatherNID,
                    FatherMobile = students.FatherMobile,
                    FatherDOB = students.FatherDOB,
                    PaternalGrandFatherName = students.PaternalGrandFatherName,
                    PaternalGrandMotherName = students.PaternalGrandMotherName,
                    MotherName = students.MotherName,
                    MotherNID = students.MotherNID,
                    MotherMobile = students.MotherMobile,
                    MotherDOB = students.MotherDOB,
                    MaternalGrandFatherName = students.MaternalGrandFatherName,
                    MaternalGrandMotherName = students.MaternalGrandMotherName,
                    StudentDOB = students.StudentDOB,
                    StudentBirthCertificateNo = students.StudentBirthCertificateNo,
                    PermanentVillage = students.PermanentVillage,
                    PermanentPost = students.PermanentPost,
                    PermanentPostCode = students.PermanentPostCode,
                    PermanentSubDistrict = students.PermanentSubDistrict,
                    PermanentDistrict = students.PermanentDistrict,
                    PresentVillage = students.PresentVillage,
                    PresentPost = students.PresentPost,
                    PresentPostCode = students.PresentPostCode,
                    PresentSubDistrict = students.PresentSubDistrict,
                    PresentDistrict = students.PresentDistrict,
                    HomeOwnerName = students.HomeOwnerName,
                    HomeOwnerMobile = students.HomeOwnerMobile,
                };
                return View(studentModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
		}

        // Sikkharthider tottho -> Class wise -> Individual Update	
        [HttpPost]
        public IActionResult StudentInformationIndividualUpdate(Admission model, int update, string ClassName)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var student = _Context.Students.Where(u => u.StudentId == model.StudentId ).FirstOrDefault();
                _Context.Students.Remove(student);
                _Context.SaveChanges();

                Admission studentModel = new Admission
                {
                    FormNo = model.FormNo,
                    StudentId = model.StudentId,
                    ClassName = model.ClassName,
                    Section = model.Section,
                    StudentNameBangla = model.StudentNameBangla,
                    StudentNameEnglish = model.StudentNameEnglish,
                    FatherName = model.FatherName,
                    FatherNID = model.FatherNID,
                    FatherMobile = model.FatherMobile,
                    FatherDOB = model.FatherDOB,
                    PaternalGrandFatherName = model.PaternalGrandFatherName,
                    PaternalGrandMotherName = model.PaternalGrandMotherName,
                    MotherName = model.MotherName,
                    MotherNID = model.MotherNID,
                    MotherMobile = model.MotherMobile,
                    MotherDOB = model.MotherDOB,
                    MaternalGrandFatherName = model.MaternalGrandFatherName,
                    MaternalGrandMotherName = model.MaternalGrandMotherName,
                    StudentDOB = model.StudentDOB,
                    StudentBirthCertificateNo = model.StudentBirthCertificateNo,
                    PermanentVillage = model.PermanentVillage,
                    PermanentPost = model.PermanentPost,
                    PermanentPostCode = model.PermanentPostCode,
                    PermanentSubDistrict = model.PermanentSubDistrict,
                    PermanentDistrict = model.PermanentDistrict,
                    PresentVillage = model.PresentVillage,
                    PresentPost = model.PresentPost,
                    PresentPostCode = model.PresentPostCode,
                    PresentSubDistrict = model.PresentSubDistrict,
                    PresentDistrict = model.PresentDistrict,
                    HomeOwnerName = model.HomeOwnerName,
                    HomeOwnerMobile = model.HomeOwnerMobile,
                };
            
                _Context.Students.Update(studentModel);
                _Context.SaveChanges();
                return RedirectToAction("StudentSearchByClass", new { ClassName = ClassName });
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }


        // Sikkharthider tottho -> Class wise -> Individual Delete	       
        public IActionResult StudentInformationIndividualDelete(int delete)
        {
            if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var student = _Context.Students.Where(u => u.StudentId == delete).FirstOrDefault();
            
                _Context.Students.Remove(student);
                _Context.SaveChanges();
                return RedirectToAction("SearchStudentInformation");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }            
        }
		
		// Search by student id
		public IActionResult SearchByStudentId(int studentId){
			if (HttpContext.Session.Get("userName") != null && accountType().Equals("AdmissionOfficer"))
            {
                //showing user name on admin pannel
                UserNameOnAdminPanel();

                var students = _Context.Students.Where(u => u.StudentId == studentId).FirstOrDefault();
				if(students != null){
					Admission studentModel = new Admission
					{
						StudentId = students.StudentId,
						ClassName = students.ClassName,
                        Section = students.Section,
                        StudentNameBangla = students.StudentNameBangla,
						StudentNameEnglish = students.StudentNameEnglish,
						FatherName = students.FatherName,
						FatherNID = students.FatherNID,
						FatherMobile = students.FatherMobile,
						FatherDOB = students.FatherDOB,
						PaternalGrandFatherName = students.PaternalGrandFatherName,
						PaternalGrandMotherName = students.PaternalGrandMotherName,
						MotherName = students.MotherName,
						MotherNID = students.MotherNID,
						MotherMobile = students.MotherMobile,
						MotherDOB = students.MotherDOB,
						MaternalGrandFatherName = students.MaternalGrandFatherName,
						MaternalGrandMotherName = students.MaternalGrandMotherName,
						StudentDOB = students.StudentDOB,
						StudentBirthCertificateNo = students.StudentBirthCertificateNo,
						PermanentVillage = students.PermanentVillage,
						PermanentPost = students.PermanentPost,
						PermanentPostCode = students.PermanentPostCode,
						PermanentSubDistrict = students.PermanentSubDistrict,
						PermanentDistrict = students.PermanentDistrict,
						PresentVillage = students.PresentVillage,
						PresentPost = students.PresentPost,
						PresentPostCode = students.PresentPostCode,
						PresentSubDistrict = students.PresentSubDistrict,
						PresentDistrict = students.PresentDistrict,
						HomeOwnerName = students.HomeOwnerName,
						HomeOwnerMobile = students.HomeOwnerMobile,
					};
				
					return View("StudentInformationIndividual", studentModel);
				}
				else{
					return RedirectToAction("SearchStudentInformation");
				}
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
