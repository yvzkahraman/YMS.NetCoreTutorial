using Microsoft.EntityFrameworkCore;
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=YMSDb2; integrated security=true;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
