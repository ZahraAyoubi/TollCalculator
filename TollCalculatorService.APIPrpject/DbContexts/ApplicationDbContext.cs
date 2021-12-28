using Microsoft.EntityFrameworkCore;
using TollCalculatorService.APIPrpject.Models;

namespace TollCalculatorService.APIPrpject.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TollFee> TollFees { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
    }
}
