﻿using System;
using System.Collections.Generic;

namespace EForm.Models
{
    public partial class InvoiceItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        public int? VATpercentage { get; set; }
        public int? InvoiceId { get; set; }
        public int? OrderItemId { get; set; }

        public virtual Invoice? Invoice { get; set; }
        public virtual OrderItem? OrderItem { get; set; }
    }
}
