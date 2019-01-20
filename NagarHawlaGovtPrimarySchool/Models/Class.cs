using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class Class
    {
        [Key]
        public int class_id { get; set; }

        [Required]
        public string class_name { get; set; }
    }

    public class ClassList
    {
        public List<Class> ClassAll { get; set; }
    }
}
