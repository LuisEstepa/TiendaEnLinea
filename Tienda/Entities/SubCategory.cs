using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SubCategory
    {
        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public bool? isActive { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
