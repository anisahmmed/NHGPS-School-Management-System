using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class RelClass
    {
        [Key]
        public int class_id {get; set;}

        [Required]
        public List<RelClassSubject> SubjectAll { get; set; }

        [Required]
        public List<RelClassSection> SectionAll { get; set; }

        [Required]
        public List<Subject> SubjectList { get; set; }

        [Required]
        public List<Section> SectionList { get; set; }

    }
}
