using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("admin_Employee")]
    public class AdminEmployee
    {
        [Key]
        [Display(Name = "ID")]
        public int EmpID { get; set; }

        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string FirstName { get; set; }

        [Required, RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name contains only Alphabets")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 99)]
        public int Age { get; set; }


        [Required, DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DOB"), DataType(DataType.Date)]
        public System.DateTime DateofBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number contains only Numbers")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public int RoleID { get; set; }
    }
}
