﻿using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class PaymentType
    {
        [Key]
        public int PayTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
