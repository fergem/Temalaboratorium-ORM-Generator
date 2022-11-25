using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public int Id { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? StatusId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Status? Status { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
