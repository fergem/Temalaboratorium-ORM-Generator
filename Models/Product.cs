using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public int? VATid { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }

        public virtual Category? Category { get; set; }
        public virtual VAT? VAT { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
