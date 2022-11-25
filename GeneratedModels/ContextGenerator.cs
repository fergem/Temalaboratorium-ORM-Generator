
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EForm.GeneratedModels
{
    public partial class TestDataBaseContext : DbContext
    {
        public TestDataBaseContext()
        {
        }

        public TestDataBaseContext(DbContextOptions<TestDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categorys { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerSite> CustomerSites { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceIssuer> InvoiceIssuers { get; set; } = null!;
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Status> Statuss { get; set; } = null!;
        public virtual DbSet<VAT> VATs { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=VIKIGEPE\\SQLEXPRESS;Initial Catalog=TestDataBase;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                 
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(50);
                        
                entity.Property(e => e.ParentCategoryID);
                                    
            });
        
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(50);
                        
                entity.Property(e => e.BankAccount).HasMaxLength(50).IsUnicode(false);
                        
                entity.Property(e => e.Login).HasMaxLength(50);
                        
                entity.Property(e => e.Password).HasMaxLength(50);
                        
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                        
                entity.Property(e => e.MainCustomerSiteID);
                        
                entity.HasOne(d => d.CustomerSite)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d. MainCustomerSiteID)
                    .HasConstraintName("Customer_MainCustomerSite");
                                
            });
        
            modelBuilder.Entity<CustomerSite>(entity =>
            {
                entity.ToTable("CustomerSite");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.ZipCode).HasMaxLength(4).IsUnicode(false);
                        
                entity.Property(e => e.City).HasMaxLength(50);
                        
                entity.Property(e => e.Street).HasMaxLength(50);
                        
                entity.Property(e => e.Tel).HasMaxLength(15).IsUnicode(false);
                        
                entity.Property(e => e.Fax).HasMaxLength(15).IsUnicode(false);
                        
                entity.Property(e => e.CustomerID);
                        
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSites)
                    .HasForeignKey(d => d. CustomerID)
                    .HasConstraintName("FK__CustomerS__Custo__32E0915F");
                                
            });
        
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.CustomerName).HasMaxLength(50);
                        
                entity.Property(e => e.CustomerZipCode).HasMaxLength(4).IsUnicode(false);
                        
                entity.Property(e => e.CustomerCity).HasMaxLength(50);
                        
                entity.Property(e => e.CustomerStreet).HasMaxLength(50);
                        
                entity.Property(e => e.PrintedCopies);
                        
                entity.Property(e => e.Cancelled);
                        
                entity.Property(e => e.PaymentMethod).HasMaxLength(20);
                        
                entity.Property(e => e.CreationDate);
                        
                entity.Property(e => e.DeliveryDate);
                        
                entity.Property(e => e.PaymentDeadline);
                        
                entity.Property(e => e.InvoiceIssuerID);
                        
                entity.Property(e => e.OrderID);
                        
                entity.HasOne(d => d.InvoiceIssuer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d. InvoiceIssuerID)
                    .HasConstraintName("FK__Invoice__Invoice__4222D4EF");
                    
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d. OrderID)
                    .HasConstraintName("FK__Invoice__OrderID__4316F928");
                                
            });
        
            modelBuilder.Entity<InvoiceIssuer>(entity =>
            {
                entity.ToTable("InvoiceIssuer");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(50);
                        
                entity.Property(e => e.ZipCode).HasMaxLength(4).IsUnicode(false);
                        
                entity.Property(e => e.City).HasMaxLength(50);
                        
                entity.Property(e => e.Street).HasMaxLength(50);
                        
                entity.Property(e => e.TaxIdentifier).HasMaxLength(20).IsUnicode(false);
                        
                entity.Property(e => e.BankAccount).HasMaxLength(50).IsUnicode(false);
                                    
            });
        
            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("InvoiceItem");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(50);
                        
                entity.Property(e => e.Amount);
                        
                entity.Property(e => e.Price);
                        
                entity.Property(e => e.VATPercentage);
                        
                entity.Property(e => e.InvoiceID);
                        
                entity.Property(e => e.OrderItemID);
                        
                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d. InvoiceID)
                    .HasConstraintName("FK__InvoiceIt__Invoi__45F365D3");
                    
                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d. OrderItemID)
                    .HasConstraintName("FK__InvoiceIt__Order__46E78A0C");
                                
            });
        
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Date);
                        
                entity.Property(e => e.Deadline);
                        
                entity.Property(e => e.CustomerSiteID);
                        
                entity.Property(e => e.StatusID);
                        
                entity.Property(e => e.PaymentMethodID);
                        
                entity.HasOne(d => d.CustomerSite)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d. CustomerSiteID)
                    .HasConstraintName("FK__Order__CustomerS__36B12243");
                    
                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d. PaymentMethodID)
                    .HasConstraintName("FK__Order__PaymentMe__38996AB5");
                    
                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d. StatusID)
                    .HasConstraintName("FK__Order__StatusID__37A5467C");
                                
            });
        
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Amount);
                        
                entity.Property(e => e.Price);
                        
                entity.Property(e => e.OrderID);
                        
                entity.Property(e => e.ProductID);
                        
                entity.Property(e => e.StatusID);
                        
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d. OrderID)
                    .HasConstraintName("FK__OrderItem__Order__3B75D760");
                    
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d. ProductID)
                    .HasConstraintName("FK__OrderItem__Produ__3C69FB99");
                    
                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d. StatusID)
                    .HasConstraintName("FK__OrderItem__Statu__3D5E1FD2");
                                
            });
        
            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Method).HasMaxLength(20);
                        
                entity.Property(e => e.Deadline);
                                    
            });
        
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(50);
                        
                entity.Property(e => e.Price);
                        
                entity.Property(e => e.Stock);
                        
                entity.Property(e => e.VATID);
                        
                entity.Property(e => e.CategoryID);
                        
                entity.Property(e => e.Description).HasMaxLength(1073741823);
                        
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d. CategoryID)
                    .HasConstraintName("FK__Product__Categor__2E1BDC42");
                    
                entity.HasOne(d => d.VAT)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d. VATID)
                    .HasConstraintName("FK__Product__VATID__2D27B809");
                                
            });
        
            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Name).HasMaxLength(20);
                                    
            });
        
            modelBuilder.Entity<VAT>(entity =>
            {
                entity.ToTable("VAT");

                
                entity.Property(e => e.ID).IsRequired();
                        
                entity.Property(e => e.Percentage);
                                    
            });
        
        }
    }
}
