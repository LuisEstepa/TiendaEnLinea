using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AdminLogin> admin_Login { get; set; }
    }
}
