using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class RelResult
    {
        [Key]
        public int result_id { get; set; }

        [Required]
        public string student_id { get; set; }

        [Required]
        public string class_name { get; set; }

        [Required]
        public string exam_type { get; set; }
        
        [Required]
        public string section { get; set; }

        [Required]
        public string subject_name { get; set; }

        [Required]
        public int marks { get; set; }

        [Required]
        public List<RelClassSubject> subject_list { get; set; }

    }
    public class RelResultList
    {
        public List<RelResult> RelResultAll { get; set; }
    }
}
