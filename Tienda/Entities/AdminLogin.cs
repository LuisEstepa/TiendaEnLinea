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
        public int UserName { get; set; }
        public int Password { get; set; }
        public int RoleType { get; set; }
        public int Notes { get; set; }

    }
}
