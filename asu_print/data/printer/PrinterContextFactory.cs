using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace printer.Database
{
    /// <summary>
    /// http://www.michael-whelan.net/ef-core-101-migrations-in-separate-assembly/
    /// </summary>
    public class PrinterContextFactory : IDbContextFactory<PrinterContext>
    {
        public PrinterContext Create(DbContextFactoryOptions options)
        {
             var builder = new DbContextOptionsBuilder<PrinterContext>();
             builder.UseNpgsql("Host=localhost;Database=Printer;Username=postgres;Password=56543");
             return new PrinterContext(builder.Options);
        }
    }   

}