using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("admin_Login")]
    public class AdminLogin
    {
        [Key]
        public int LoginID { get; set; }
        public int EmpID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleType { get; set; }
        public string Notes { get; set; }

        [ForeignKey("EmpID")]
        public virtual AdminEmployee admin_Employee { get; set; }

        [ForeignKey("RoleType")]
        public virtual Role Role { get; set; }

    }
}
