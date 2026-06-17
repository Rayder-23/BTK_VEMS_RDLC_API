using Microsoft.EntityFrameworkCore;
using VEMS.PrintEngine.Models;

namespace VEMS.PrintEngine.Data
{
    public class VemsDbContext : DbContext
    {
        public VemsDbContext(DbContextOptions<VemsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tells EF Core that this model maps to custom SQL queries, not a physical database table
            modelBuilder.Entity<FeeVoucherReportModel>().HasNoKey();
        }
    }
}