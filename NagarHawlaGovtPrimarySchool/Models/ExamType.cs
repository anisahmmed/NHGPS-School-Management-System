using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class ExamType
    {
        [Key]
        public int exam_id { get; set; }

        [Required]
        public string exam_type { get; set; }
    }
	
    public class ExamTypeList
    {
        public List<ExamType> ExamTypeAll { get; set; }
    }
}
