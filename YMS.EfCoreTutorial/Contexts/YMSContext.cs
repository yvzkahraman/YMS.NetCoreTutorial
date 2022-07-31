using Microsoft.EntityFrameworkCore;
using YMS.EfCoreTutorial.Configurations;
using YMS.EfCoreTutorial.Entities;

namespace YMS.EfCoreTutorial.Contexts
{
    // kuş bir hayandır
    // at bir hayvandır
    // naming conventions
    // function => UpperCase GetAll() LowerCase => getAll();
    public class YMSContext : DbContext
    {
        public YMSContext(DbContextOptions<YMSContext> options) :base(options)
        {

        }
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<AppRole> AppRoles =>Set<AppRole>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
