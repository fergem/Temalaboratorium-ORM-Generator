using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Method { get; set; }
        public int? Deadline { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
