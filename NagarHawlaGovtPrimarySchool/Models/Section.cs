using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class Section
    {
        [Key]
        public int sec_id { get; set; }

        [Required]
        public string section { get; set; }
    }

    public class SectionList
    {
        public List<Section> SectionAll { get; set; }
    }

}
