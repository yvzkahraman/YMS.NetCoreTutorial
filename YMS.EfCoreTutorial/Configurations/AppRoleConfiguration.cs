using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMS.EfCoreTutorial.Entities;

namespace YMS.EfCoreTutorial.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(x => x.Definition).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.AppUsers).WithOne(x => x.AppRole).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
