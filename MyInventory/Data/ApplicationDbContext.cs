using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MyInventory.Models;

namespace MyInventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            //try
            //{
            //    var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            //    if (databaseCreator != null)
            //    {
            //        if (!databaseCreator.CanConnect())
            //        {
            //            databaseCreator.Create();
            //        }
            //        if (!databaseCreator.HasTables())
            //        {
            //            databaseCreator.CreateTables();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Tm> Tms { get; set; }
        public DbSet<PMS> PMS { get; set; }
        public DbSet<AfterEnablingMig> AfterEnablingMigs { get; set; }
        public DbSet<Radit> Radit { get; set; }
        public DbSet<ClassTest> ClassTests { get; set; }
        public DbSet<ClassA> ClassA { get; set; }
        public DbSet<ClassC> ClassC { get; set; }
    }
}