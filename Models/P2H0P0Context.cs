using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EForm.Models
{
    public partial class P2H0P0Context : DbContext
    {
        public P2H0P0Context()
        {
        }

        public P2H0P0Context(DbContextOptions<P2H0P0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerSite> CustomerSites { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceIssuer> InvoiceIssuers { get; set; } = null!;
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<VAT> VATs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=P2H0P0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK__Category__Parent__2A4B4B5E");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.MainCustomerSiteId).HasColumnName("MainCustomerSiteID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.MainCustomerSite)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MainCustomerSiteId)
                    .HasConstraintName("Customer_MainCustomerSite");
            });

            modelBuilder.Entity<CustomerSite>(entity =>
            {
                entity.ToTable("CustomerSite");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSites)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerS__Custo__32E0915F");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerCity).HasMaxLength(50);

                entity.Property(e => e.CustomerName).HasMaxLength(50);

                entity.Property(e => e.CustomerStreet).HasMaxLength(50);

                entity.Property(e => e.CustomerZipCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceIssuerId).HasColumnName("InvoiceIssuerID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentDeadline).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod).HasMaxLength(20);

                entity.HasOne(d => d.InvoiceIssuer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceIssuerId)
                    .HasConstraintName("FK__Invoice__Invoice__4222D4EF");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Invoice__OrderID__4316F928");
            });

            modelBuilder.Entity<InvoiceIssuer>(entity =>
            {
                entity.ToTable("InvoiceIssuer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.TaxIdentifier)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("InvoiceItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.VATpercentage).HasColumnName("VATPercentage");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK__InvoiceIt__Invoi__45F365D3");

                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.InvoiceItems)
                    .HasForeignKey(d => d.OrderItemId)
                    .HasConstraintName("FK__InvoiceIt__Order__46E78A0C");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerSiteId).HasColumnName("CustomerSiteID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.CustomerSite)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerSiteId)
                    .HasConstraintName("FK__Order__CustomerS__36B12243");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Order__PaymentMe__38996AB5");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Order__StatusID__37A5467C");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__3B75D760");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__Produ__3C69FB99");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__OrderItem__Statu__3D5E1FD2");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Method).HasMaxLength(20);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).HasColumnType("xml");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.VATid).HasColumnName("VATID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__2E1BDC42");

                entity.HasOne(d => d.VAT)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VATid)
                    .HasConstraintName("FK__Product__VATID__2D27B809");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<VAT>(entity =>
            {
                entity.ToTable("VAT");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
