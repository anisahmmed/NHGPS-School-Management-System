using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NagarHawlaGovtPrimarySchool.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name is mendatory.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is mendatory.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is mendatory.")]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mendatory.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Type is mendatory.")]
        public string AccountType { get; set; }
    }

    public class AdminList
    {
        public List<User> AdminAll { get; set; }
    }
}
