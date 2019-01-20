using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class RelClassSection
    {
        [Key]
        public int class_section_id { get; set; }

        [Required]
        public string class_name { get; set; }

        [Required]
        public string section_name { get; set; }

    }
    public class RelClassSectionList
    {
        public List<RelClassSection> SectionAll { get; set; }
    }
    
}
