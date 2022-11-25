using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class CustomerSite
    {
        public CustomerSite()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Tel { get; set; }
        public string? Fax { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
