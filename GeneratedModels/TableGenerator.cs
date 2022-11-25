
using System;
using System.Collections.Generic;
namespace EForm.GeneratedModels
{
    public partial class Category
    {
        public Category()
        {
            
            Categorys = new HashSet<Category>();
                
            Products = new HashSet<Product>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public Int32? ParentCategoryID { get; set; }
                    
        public virtual Category? ParentCategory { get; set; }
                
        public virtual ICollection<Category> Categorys { get; set; }
                
        public virtual ICollection<Product> Products { get; set; }
                           
         
    }
    public partial class Customer
    {
        public Customer()
        {
            
            CustomerSites = new HashSet<CustomerSite>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public String? BankAccount { get; set; }
                    
        public String? Login { get; set; }
                    
        public String? Password { get; set; }
                    
        public String? Email { get; set; }
                    
        public Int32? MainCustomerSiteID { get; set; }
                    
        public virtual CustomerSite? CustomerSite { get; set; }
                
        public virtual ICollection<CustomerSite> CustomerSites { get; set; }
                           
         
    }
    public partial class CustomerSite
    {
        public CustomerSite()
        {
            
            Customers = new HashSet<Customer>();
                
            Orders = new HashSet<Order>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? ZipCode { get; set; }
                    
        public String? City { get; set; }
                    
        public String? Street { get; set; }
                    
        public String? Tel { get; set; }
                    
        public String? Fax { get; set; }
                    
        public Int32? CustomerID { get; set; }
                    
        public virtual Customer? Customer { get; set; }
                
        public virtual ICollection<Customer> Customers { get; set; }
                
        public virtual ICollection<Order> Orders { get; set; }
                           
         
    }
    public partial class Invoice
    {
        public Invoice()
        {
            
            InvoiceItems = new HashSet<InvoiceItem>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? CustomerName { get; set; }
                    
        public String? CustomerZipCode { get; set; }
                    
        public String? CustomerCity { get; set; }
                    
        public String? CustomerStreet { get; set; }
                    
        public Int32? PrintedCopies { get; set; }
                    
        public Boolean? Cancelled { get; set; }
                    
        public String? PaymentMethod { get; set; }
                    
        public DateTime? CreationDate { get; set; }
                    
        public DateTime? DeliveryDate { get; set; }
                    
        public DateTime? PaymentDeadline { get; set; }
                    
        public Int32? InvoiceIssuerID { get; set; }
                    
        public Int32? OrderID { get; set; }
                    
        public virtual InvoiceIssuer? InvoiceIssuer { get; set; }
                
        public virtual Order? Order { get; set; }
                
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
                           
         
    }
    public partial class InvoiceIssuer
    {
        public InvoiceIssuer()
        {
            
            Invoices = new HashSet<Invoice>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public String? ZipCode { get; set; }
                    
        public String? City { get; set; }
                    
        public String? Street { get; set; }
                    
        public String? TaxIdentifier { get; set; }
                    
        public String? BankAccount { get; set; }
                    
        public virtual ICollection<Invoice> Invoices { get; set; }
                           
         
    }
    public partial class InvoiceItem
    {
        public InvoiceItem()
        {
                        
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public Int32? Amount { get; set; }
                    
        public Double? Price { get; set; }
                    
        public Int32? VATPercentage { get; set; }
                    
        public Int32? InvoiceID { get; set; }
                    
        public Int32? OrderItemID { get; set; }
                    
        public virtual Invoice? Invoice { get; set; }
                
        public virtual OrderItem? OrderItem { get; set; }
                           
         
    }
    public partial class Order
    {
        public Order()
        {
            
            Invoices = new HashSet<Invoice>();
                
            OrderItems = new HashSet<OrderItem>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public DateTime? Date { get; set; }
                    
        public DateTime? Deadline { get; set; }
                    
        public Int32? CustomerSiteID { get; set; }
                    
        public Int32? StatusID { get; set; }
                    
        public Int32? PaymentMethodID { get; set; }
                    
        public virtual CustomerSite? CustomerSite { get; set; }
                
        public virtual PaymentMethod? PaymentMethod { get; set; }
                
        public virtual Status? Status { get; set; }
                
        public virtual ICollection<Invoice> Invoices { get; set; }
                
        public virtual ICollection<OrderItem> OrderItems { get; set; }
                           
         
    }
    public partial class OrderItem
    {
        public OrderItem()
        {
            
            InvoiceItems = new HashSet<InvoiceItem>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public Int32? Amount { get; set; }
                    
        public Double? Price { get; set; }
                    
        public Int32? OrderID { get; set; }
                    
        public Int32? ProductID { get; set; }
                    
        public Int32? StatusID { get; set; }
                    
        public virtual Order? Order { get; set; }
                
        public virtual Product? Product { get; set; }
                
        public virtual Status? Status { get; set; }
                
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
                           
         
    }
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            
            Orders = new HashSet<Order>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Method { get; set; }
                    
        public Int32? Deadline { get; set; }
                    
        public virtual ICollection<Order> Orders { get; set; }
                           
         
    }
    public partial class Product
    {
        public Product()
        {
            
            OrderItems = new HashSet<OrderItem>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public Double? Price { get; set; }
                    
        public Int32? Stock { get; set; }
                    
        public Int32? VATID { get; set; }
                    
        public Int32? CategoryID { get; set; }
                    
        public String? Description { get; set; }
                    
        public virtual Category? Category { get; set; }
                
        public virtual VAT? VAT { get; set; }
                
        public virtual ICollection<OrderItem> OrderItems { get; set; }
                           
         
    }
    public partial class Status
    {
        public Status()
        {
            
            Orders = new HashSet<Order>();
                
            OrderItems = new HashSet<OrderItem>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public String? Name { get; set; }
                    
        public virtual ICollection<Order> Orders { get; set; }
                
        public virtual ICollection<OrderItem> OrderItems { get; set; }
                           
         
    }
    public partial class VAT
    {
        public VAT()
        {
            
            Products = new HashSet<Product>();
                            
        }
            
        public Int32 ID { get; set; }
                    
        public Int32? Percentage { get; set; }
                    
        public virtual ICollection<Product> Products { get; set; }
                           
         
    }
        
}

