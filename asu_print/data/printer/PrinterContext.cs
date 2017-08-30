using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;

namespace printer.Database
{
    public sealed class PrinterContext : DbContext
    {    
        public static void Configure(DbContextOptionsBuilder optionsBuilder,string connectionString){                        
            optionsBuilder.UseNpgsql(connectionString);
        }
        public PrinterContext(){}

        public PrinterContext(DbContextOptions<PrinterContext> options)
            :base(options){ }

        public DbSet<Printer> Printers { get; set; }
        public DbSet<Model> Models { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Zip> Zips { get; set; }

        public DbSet<ModelZip> ModelsZips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ModelZip>().HasKey(a => new {a.ModelId, a.ZipId});
        }
    }
}