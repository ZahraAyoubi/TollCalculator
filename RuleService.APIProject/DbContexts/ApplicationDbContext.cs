using Microsoft.EntityFrameworkCore;
using RuleService.APIProject.Models;

namespace RuleService.APIProject.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TollFee> TollFees { get; set; }
        public DbSet<CostType> CostTypes { get; set; }  
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<TollFreeVehicle> TollFreeVehicles { get; set; }      
    }
}

