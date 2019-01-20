using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class RelClassSubject
    {
        [Key]
        public int class_subect_id { get; set; }

        [Required]
        public string class_name { get; set; }

        [Required]
        public string subject_name { get; set; }
    }

    public class RelClassSubjectList
    {
        public List<RelClassSubject> RelClassSubjectAll { get; set; }
    }
}
