using Domain.Model;
using Domain.Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //modelBuilder.Entity<Product>().HasOne<Brand>(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            //modelBuilder.Entity<Product>().HasOne<Category>(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);
            //modelBuilder.Entity<FatherProduct>().HasKey(x => x.Id);
            modelBuilder.Entity<Laptop>().ToTable("Laptop");
            modelBuilder.Entity<MFU>().ToTable("MFU");
            modelBuilder.Entity<Display>().ToTable("Display");
            modelBuilder.Entity<Speaker>().ToTable("Speaker");


            modelBuilder.Entity<Order>().HasOne<Customer>(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
            modelBuilder.Entity<Order>().HasOne<Product>(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId);


            modelBuilder.Entity<Customer>().Property(x=>x.PhotoPath).IsRequired(false);//Column E-Mail is nullable
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(25); //maxLength  column
            modelBuilder.Entity<Customer>().Property(x => x.SurName).HasMaxLength(25); //maxLength  column
            modelBuilder.Entity<Customer>().Property(x => x.Login).HasMaxLength(25);//maxLength  column
            modelBuilder.Entity<Customer>().Property(x => x.Password).HasMaxLength(25); //maxLength  column
            modelBuilder.Entity<Customer>().Property(x => x.Login).HasMaxLength(50);//maxLength  column

            modelBuilder.Entity<Customer>().HasAlternateKey(x => x.Login); // Login unique

            modelBuilder.Entity<Brand>().HasAlternateKey(x => x.Name);//unique Name
            modelBuilder.Entity<Brand>().Property(x => x.Name).IsRequired(true);//Column Name not nullable
            modelBuilder.Entity<Brand>().Property(x => x.Name).HasMaxLength(50);//MaxLength Name

            modelBuilder.Entity<Category>().HasAlternateKey(x => x.Name);//unique Name
            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired(true);//Column Name not nullable
            modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(50);//MaxLength Name
            modelBuilder.Entity<Category>().Property(x => x.PhotoCategory).IsRequired(false);

            modelBuilder.Entity<Product>().Property(x => x.Model).HasMaxLength(50);//MaxLength Name
            modelBuilder.Entity<Product>().Property(x => x.Discription).HasMaxLength(150);//MaxLength Name
            modelBuilder.Entity<Product>().Property(x => x.Model).IsRequired(true);//Column  not nullable
            modelBuilder.Entity<Product>().Property(x => x.Photo).IsRequired(false);//Column not nullable

            modelBuilder.Entity<MFU>().Property(x => x.DPI).HasMaxLength(15);//MaxLength Name
            modelBuilder.Entity<MFU>().Property(x => x.DPI).IsRequired(true);//Column Name not nullable


            modelBuilder.Entity<Display>().Property(x => x.Resolution).HasMaxLength(15);//MaxLength Resolution
            modelBuilder.Entity<Display>().Property(x => x.Resolution).IsRequired(true);//Column Name not nullable
            modelBuilder.Entity<Display>().Property(x => x.Color).HasMaxLength(15);//MaxLength Name
            modelBuilder.Entity<Display>().Property(x => x.Color).IsRequired(true);//Column Name not nullable

            modelBuilder.Entity<Speaker>().Property(x => x.Color).IsRequired(true);//Column Name not nullable
            modelBuilder.Entity<Speaker>().Property(x => x.Color).HasMaxLength(15);//MaxLength Name


            #region Add In Db
            modelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 1, BrandId = 1, CategoryID = 2, Price = 22200, Model = "L1", Discription = "Laptop", Hdd = 120, Processor = "I5" , Ram=4, Count=12 , Photo= "https://klike.net/uploads/posts/2020-04/1586244741_1.jpg" });
            modelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 2, BrandId = 2, CategoryID = 2, Price = 34400, Model = "L2", Discription = "Laptop", Hdd = 240, Processor = "I7",  Ram = 12, Count = 8, Photo = "https://klike.net/uploads/posts/2020-04/1586244779_2.jpg" });
            modelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 3, BrandId = 3, CategoryID = 2, Price = 12200, Model = "L3", Discription = "Laptop", Hdd = 512, Processor = "I3",  Ram = 8, Count = 3,Photo = "https://klike.net/uploads/posts/2020-04/1586244761_4.jpg" });
            modelBuilder.Entity<Laptop>().HasData(new Laptop { Id = 4, BrandId = 2, CategoryID = 2, Price = 15600, Model = "L4", Discription = "Laptop", Hdd = 240, Processor = "Celeron", Ram = 16, Count = 1, Photo= "https://klike.net/uploads/posts/2020-04/1586244770_7.jpg" });

            modelBuilder.Entity<MFU>().HasData(new MFU { Id = 5, BrandId = 1, CategoryID = 1, Price = 15600, Model = "P4", Discription = "Printers", PrinterType = PrinterType.Laser, DPI="600*1200", HasWiFi = true, ColorCount=1, Count = 3, Photo= "https://tech-choice.net/wp-content/uploads/2019/09/mfu-dlja-pechati-foto-620x330.jpg" });
            modelBuilder.Entity<MFU>().HasData(new MFU { Id = 6, BrandId = 3, CategoryID = 1, Price = 15600, Model = "P4", Discription = "Printers", PrinterType = PrinterType.Laser, DPI = "600*1200", HasWiFi = true, ColorCount = 4, Count = 8, Photo = "https://cdn.27.ua/799/1f/3c/7996_2.jpeg" });
            modelBuilder.Entity<MFU>().HasData(new MFU { Id = 7, BrandId = 2, CategoryID = 1, Price = 15600, Model = "P4", Discription = "Printers", PrinterType = PrinterType.Laser , DPI = "600*1200", HasWiFi = false, ColorCount = 6, Count = 3, Photo = "https://images.prom.ua/2937801366_mfu-a4-epson.jpg" });
            modelBuilder.Entity<MFU>().HasData(new MFU { Id = 8, BrandId = 1, CategoryID = 1, Price = 15600, Model = "P4", Discription = "Printers", PrinterType = PrinterType.Laser, DPI = "600*1200", HasWiFi = true, ColorCount = 1, Count = 5 , Photo = "https://images.prom.ua/2800565290_w640_h640_polnoe-reshenie-mfu.jpg" });


            modelBuilder.Entity<Display>().HasData(new Display { Id = 9, BrandId = 1, CategoryID = 3, Price = 4560, Model = "D1", Discription = "Diіз", Color = "Blask", DiagonalSize=21, Resolution="1280*1024", Count = 3 ,Photo= "https://img.freepik.com/free-photo/computer_1205-717.jpg?1" });
            modelBuilder.Entity<Display>().HasData(new Display { Id = 10, BrandId = 2, CategoryID = 3, Price = 4860, Model = "D2", Discription = "Diіз", Color = "Blask", DiagonalSize = 21, Resolution = "1280*1024", Count = 1, Photo = "https://cdn.fotosklad.ru/unsafe/73e5a00a41ff440c925b9b1a460df709/image.jpg" });
            modelBuilder.Entity<Display>().HasData(new Display { Id = 11, BrandId = 3, CategoryID = 3, Price = 4960, Model = "D3", Discription = "Diіз", Color = "Blask", DiagonalSize = 21, Resolution = "1280*1024", Count = 2, Photo = "https://st.depositphotos.com/1035837/1386/i/600/depositphotos_13861529-stock-photo-monitor.jpg" });
            modelBuilder.Entity<Display>().HasData(new Display { Id = 12, BrandId = 1, CategoryID = 3, Price = 4560, Model = "D4", Discription = "Diіз", Color = "Blask", DiagonalSize = 21, Resolution = "1280*1024", Count = 3, Photo = "https://images.unian.net/photos/2022_07/thumb_files/400_0_1656777669-2895.jpg?r=799803" });

            modelBuilder.Entity<Speaker>().HasData(new Speaker { Id = 13, BrandId = 1, CategoryID = 4, Price = 560, Model = "S4", Discription = "Diіз", Color = "Blask", Power=12, Heigth=20, Width=30, Count = 3, Photo= "https://st2.depositphotos.com/1001877/5970/i/950/depositphotos_59701653-stock-photo-group-of-audio-speakers-loudspeakers.jpg" });
            modelBuilder.Entity<Speaker>().HasData(new Speaker { Id = 14, BrandId = 2, CategoryID = 4, Price = 230, Model = "S4", Discription = "Diіз", Color = "Blask", Power = 12, Heigth = 20, Width = 30, Count = 5, Photo = "https://assets.simant.com.ua/images/products/bigest/2559.jpg" });
            modelBuilder.Entity<Speaker>().HasData(new Speaker { Id = 15, BrandId = 3, CategoryID = 4, Price = 660, Model = "S4", Discription = "Diіз", Color = "Blask", Power = 12, Heigth = 20, Width = 30, Count = 2, Photo = "https://assets.simant.com.ua/images/products/bigest/2668.jpg" });
            modelBuilder.Entity<Speaker>().HasData(new Speaker { Id = 16, BrandId = 3, CategoryID = 4, Price = 860, Model = "S4", Discription = "Diіз", Color = "Blask", Power = 12, Heigth = 20, Width = 30, Count = 1, Photo = "https://assets.simant.com.ua/images/products/bigest/2614.jpg" });



            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "HP", PhotoLogo = "https://fixcenter.com.ua/content/uploads/images/serveryhp.png" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id=2, Name = "Dell", PhotoLogo = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Dell_logo_2016.svg/200px-Dell_logo_2016.svg.png" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id=3, Name = "Samsung", PhotoLogo = "https://upload.wikimedia.org/wikipedia/uk/thumb/2/24/Samsung_Logo.svg/1280px-Samsung_Logo.svg.png" });

            modelBuilder.Entity<Category>().HasData(new Category { Id=1,Name= "MFU", PhotoCategory= "https://images.prom.ua/3060125370_w640_h640_mfu-lazernoe-xerox.jpg" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=2,Name= "Laptops", PhotoCategory= "https://www.notebookcheck-ru.com/uploads/tx_nbc2/MicrosoftSurfaceLaptop3-15__1__02.JPG" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Displays", PhotoCategory= "https://www.lg.com/in/images/monitors/md07543925/gallery/27MP400-B-D-01.jpg" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Speakers",PhotoCategory = "https://shop.sven.ua/image/cache/catalog/products-sven/acoustic_plast/sven_445_01-1200x800.png" });


            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, Name = "Serg", SurName = "Potalicyn", Login = "Admin", Password = "1", Email = "Serg@ukr.net", Phone = 098453423 , TypeUser=TypeUser.Admin, PhotoPath= "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, Name = "Victoria", SurName = "Naymenko", Login = "Vika", Password = "1", Email = "Vika@ukr.net", Phone = 098453424, TypeUser = TypeUser.Client, PhotoPath = "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 3, Name = "Alex", SurName = "Kudrynskuy", Login = "Alex", Password = "1", Email = "Alex@ukr.net", Phone = 098453425, TypeUser = TypeUser.Client, PhotoPath = "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });

            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 4, Name = "Igor", SurName = "Petrenko", Login = "Igor", Password = "1", Email = "Igor@ukr.net", Phone = 098453423, TypeUser = TypeUser.Client, PhotoPath = "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 5, Name = "Dima", SurName = "Ivanenko", Login = "Dima", Password = "1", Email = "Dima@ukr.net", Phone = 098453424, TypeUser = TypeUser.Client, PhotoPath = "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 6, Name = "Maria", SurName = "Sergienko", Login = "Maria", Password = "1", Email = "Maria@ukr.net", Phone = 098453425, TypeUser = TypeUser.Client, PhotoPath = "https://abrakadabra.fun/uploads/posts/2022-03/1647771755_4-abrakadabra-fun-p-belii-chelovek-dlya-prezentatsii-5.png" });


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

            #endregion
            base.OnModelCreating(modelBuilder);
        }
         
        
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        
        public DbSet<Product> Products  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MFU> MFUs { get; set; }
        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Display> Displays { get; set; }
        public DbSet<Speaker> Speakers { get; set; }

    }
}
