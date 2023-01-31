using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dll.Context
{
    public class CompStoreContext:DbContext
    {
     public CompStoreContext(DbContextOptions<CompStoreContext> dbContextOptions):base(dbContextOptions) 
     {
            Database.EnsureCreated();   
     }
        protected  override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Product>().HasOne<Brand>(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            modelBuilder.Entity<Product>().HasOne<Category>(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);

            modelBuilder.Entity<Order>().HasOne<Customer>(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<Order>().HasOne<Product>(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<Brand>().HasData(new Brand {Id=1,  Name = "HP", Logo = "ImgHp" , Description="HpDescr"});
            modelBuilder.Entity<Brand>().HasData(new Brand { Id=2, Name = "Dell", Logo = "ImgDell" , Description="DellDescr"});
            modelBuilder.Entity<Brand>().HasData(new Brand { Id=3, Name = "Samsung", Logo = "ImgSamsung", Description = "SamsungDescr" });

            modelBuilder.Entity<Category>().HasData(new Category { Id=1,NameCategory = "Printers" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=2,NameCategory = "Laptops" });

            modelBuilder.Entity<Product>().HasData(new Product { Id=1, BrandId = 1, CategoryID = 1, Price=4200, Model = "MFU3010", Discription = "Printer && Scaner" });
            modelBuilder.Entity<Product>().HasData(new Product { Id=2,BrandId = 3, CategoryID = 1, Price = 4500, Model = "SCX3200", Discription = "Printer && Scaner" });
            modelBuilder.Entity<Product>().HasData(new Product { Id=3,BrandId = 3, CategoryID = 1, Price = 4300, Model = "SCX4200", Discription = "Printer && Scaner" });
            modelBuilder.Entity<Product>().HasData(new Product { Id=4, BrandId = 2, CategoryID = 2, Price = 22200, Model = "Inspiron 5110", Discription = "Laptop" });
            modelBuilder.Entity<Product>().HasData(new Product { Id=5, BrandId = 1, CategoryID = 2, Price = 23200, Model = "ElliteBool", Discription = "EliteLaptop" });

            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, Name = "Serg", SurName = "Potalicyn", Login = "Serg", Password = "1", Email = "Serg@ukr.net", Phone = 098453423 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, Name = "Victoria", SurName = "Naymenko", Login = "Vika", Password = "1", Email = "Vika@ukr.net", Phone = 098453424 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 3, Name = "Alex", SurName = "Kudrynskuy", Login = "Alex", Password = "1", Email = "Alex@ukr.net", Phone = 098453425 });

            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 4, Name = "Igor", SurName = "Petrenko", Login = "Igor", Password = "1", Email = "Igor@ukr.net", Phone = 098453423 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 5, Name = "Dima", SurName = "Ivanenko", Login = "Dima", Password = "1", Email = "Dima@ukr.net", Phone = 098453424 });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 6, Name = "Maria", SurName = "Sergienko", Login = "Maria", Password = "1", Email = "Maria@ukr.net", Phone = 098453425 });


            modelBuilder.Entity<Order>().HasData(new Order { Id = 1, CustomerId = 1, ProductId = 1, Status = true, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 2, CustomerId = 6, ProductId = 2, Status = false, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 3, CustomerId = 3, ProductId = 3, Status = true, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 4, CustomerId = 4, ProductId = 4, Status = false, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 5, CustomerId = 2, ProductId = 5, Status = true, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 6, CustomerId = 3, ProductId = 3, Status = false, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 7, CustomerId = 5, ProductId = 2, Status = true, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 8, CustomerId = 2, ProductId = 1, Status = false, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 9, CustomerId = 1, ProductId = 2, Status = true, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 10, CustomerId = 4, ProductId = 1, Status = false, DateOrder = DateTime.Now });
            modelBuilder.Entity<Order>().HasData(new Order { Id = 11, CustomerId = 6, ProductId = 5, Status = true, DateOrder = DateTime.Now });

            base.OnModelCreating(modelBuilder);
        }
         
        
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        
        public DbSet<Product> Products  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
