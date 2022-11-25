using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class VAT
    {
        public VAT()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? Percentage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
