using Microsoft.EntityFrameworkCore;

namespace Truckoom_Assesment.Models
{
    public class ApplicationDbContext:DbContext
    {
        public class ApplicationDbcontext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<MaintenanceActivity> MaintenanceActivity { get; set; }
    }

}
