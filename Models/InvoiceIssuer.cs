﻿using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class InvoiceIssuer
    {
        public InvoiceIssuer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? TaxIdentifier { get; set; }
        public string? BankAccount { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
