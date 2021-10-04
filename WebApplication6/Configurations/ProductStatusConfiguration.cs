using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication6.Entity;

namespace WebApplication6.Configurations
{
    public class ProductStatusConfiguration : IEntityTypeConfiguration<ProductStatus>
    {
        public void Configure(EntityTypeBuilder<ProductStatus> builder)
        {
            builder.ToTable("ProductStatuses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            
        }
    }
}
