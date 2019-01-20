using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class Admission
    {
        public int AdmissionId { get; set; }

        [Required]
        public int FormNo { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public string Section { get; set; }


        [Required]
        public string StudentNameBangla { get; set; }

        [Required]
        public string StudentNameEnglish { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        [MaxLength(17), MinLength(17)]
        public string FatherNID { get; set; }

        [Required]
        [MaxLength(14), MinLength(11)]
        public string FatherMobile { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FatherDOB { get; set; }

        [Required]
        public string PaternalGrandFatherName { get; set; }

        [Required]
        public string PaternalGrandMotherName { get; set; }

        [Required]
        public string MotherName { get; set; }

        [Required]
        [MaxLength(17), MinLength(17)]
        public string MotherNID { get; set; }

        [Required]
        [MaxLength(14), MinLength(11)]
        public string MotherMobile { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MotherDOB { get; set; }

        [Required]
        public string MaternalGrandFatherName { get; set; }

        [Required]
        public string MaternalGrandMotherName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StudentDOB { get; set; }

        [Required]
        public int StudentBirthCertificateNo { get; set; }

        [Required]
        public string PermanentVillage { get; set; }

        [Required]
        public string PermanentPost { get; set; }

        [Required]
        public string PermanentPostCode { get; set; }

        [Required]
        public string PermanentSubDistrict { get; set; }

        [Required]
        public string PermanentDistrict { get; set; }

        [Required]
        public string PresentVillage { get; set; }

        [Required]
        public string PresentPost { get; set; }

        [Required]
        public string PresentPostCode { get; set; }

        [Required]
        public string PresentSubDistrict { get; set; }

        [Required]
        public string PresentDistrict { get; set; }
        public string HomeOwnerName { get; set; }
        public string HomeOwnerMobile { get; set; }
    }

    public class StudentList
    {
        public List<Admission> StudentAll { get; set; }
    }

}
