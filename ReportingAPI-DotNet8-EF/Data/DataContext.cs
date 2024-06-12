using Microsoft.EntityFrameworkCore;
using ReportingAPI_DotNet8_EF.Entities;

namespace ReportingAPI_DotNet8_EF.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.Property(e => e.TotalDue)
                    .HasColumnType("decimal(18, 2)");
            });
        }
    }
}
