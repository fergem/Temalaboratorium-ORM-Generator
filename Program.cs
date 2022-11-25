using EForm.GeneratedModels;
using EForm.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Provider=sqloledb;Data Source=VIKIGEPE\\SQLEXPRESS;Initial Catalog=TestDataBase;Integrated Security=SSPI;";
        string connectionStringWithoutProvider = "Data Source=VIKIGEPE\\SQLEXPRESS;Initial Catalog=TestDataBase;Integrated Security=SSPI;";
        var optionsBuilder = new DbContextOptionsBuilder<TestDataBaseContext>();
        optionsBuilder.UseSqlServer(connectionStringWithoutProvider);
        using (var connection = new OleDbConnection(connectionString))
        {
            // Connect to the database then retrieve the schema information.  
            connection.Open();

            //For the Tables
            string[] restrictionsT = new string[4];
            restrictionsT[3] = "Table";
            DataTable table = connection.GetSchema("Tables", restrictionsT);
            //DisplayData(table);

            //For the Columns
            string[] restrictionsAtt = new string[4];
            restrictionsAtt[1] = "dbo";
            DataTable attributes = connection.GetSchema("Columns", restrictionsAtt);
            //DisplayData(attributes);


            //For the ForeignKeys
            string[] restrictionsFK = { null };
            DataTable fk = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictionsFK);
            //DisplayData(fk);
        }
        using (var db = new P2H0P0Context())
        {
            Console.WriteLine("Using simple entity framework");
            Console.WriteLine("Egy könnyebb lekérdezés:");
            var productStockQuery = from p in db.Products
                                    where p.Stock > 30
                                    select p;

            foreach (var p in productStockQuery)
            {
                Console.WriteLine($"\tName={p.Name}\tStock={p.Stock}");
            }

            Console.WriteLine("Egy nehezebb lekérdezés:");
            var orderTotalQuery2 = db.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.CustomerSite)
                .Include(o => o.CustomerSite.Customer)
                .Where(o => o.OrderItems.Sum(oi => oi.Amount * oi.Price) > 30000);
            foreach (var o in orderTotalQuery2)
            {
                Console.WriteLine("\tName={0}", o.CustomerSite.Customer.Name);
                foreach (var oi in o.OrderItems)
                {
                    Console.WriteLine($"\t\tProduct={oi.Product.Name}\tPrice={oi.Price}\tAmount={oi.Amount}");
                }
            }
        }
        Console.WriteLine("--------------------");
        using (var db = new TestDataBaseContext(optionsBuilder.Options))
        {
            Console.WriteLine("Using my entity framework");
            Console.WriteLine("Egy könnyebb lekérdezés:");
            var productStockQuery2 = from d in db.Products
                                    where d.Stock > 30
                                    select d;

            foreach (var d in productStockQuery2)
            {
                Console.WriteLine($"\tName={d.Name}\tStock={d.Stock}");
            }

            Console.WriteLine("Egy nehezebb lekérdezés:");
            var orderTotalQuery2 = db.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Include(o => o.CustomerSite)
                .Include(o => o.CustomerSite.Customer)
                .Where(o => o.OrderItems.Sum(oi => oi.Amount * oi.Price) > 30000);
            foreach (var o in orderTotalQuery2)
            {
                Console.WriteLine("\tName={0}", o.CustomerSite.Customer.Name);
                foreach (var oi in o.OrderItems)
                {
                    Console.WriteLine($"\t\tProduct={oi.Product.Name}\tPrice={oi.Price}\tAmount={oi.Amount}");
                }
            }
        }
    }

    private static void DisplayData(System.Data.DataTable table)
    {
        foreach (System.Data.DataRow row in table.Rows)
        {
            foreach (System.Data.DataColumn col in table.Columns)
            {
                Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
            }
            Console.WriteLine("============================");
        }      
    }
}