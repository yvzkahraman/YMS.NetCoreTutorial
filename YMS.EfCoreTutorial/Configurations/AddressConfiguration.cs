using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YMS.EfCoreTutorial.Entities;

namespace YMS.EfCoreTutorial.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Definition).IsRequired().HasMaxLength(500);
        }
    }
}
