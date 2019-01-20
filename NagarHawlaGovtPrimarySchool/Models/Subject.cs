using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class Subject
    {
        [Key]
        public int sub_id { get; set; }

        [Required]
        public int sub_code { get; set; }

        [Required]
        public string sub_name { get; set; }
    }
    public class SubjectList
    {
        public List<Subject> SubjectAll { get; set; }
    }
}
