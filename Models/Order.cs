using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CustomerSiteId { get; set; }
        public int? StatusId { get; set; }
        public int? PaymentMethodId { get; set; }

        public virtual CustomerSite? CustomerSite { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
