using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerSites = new HashSet<CustomerSite>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BankAccount { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public int? MainCustomerSiteId { get; set; }

        public virtual CustomerSite? MainCustomerSite { get; set; }
        public virtual ICollection<CustomerSite> CustomerSites { get; set; }
    }
}
