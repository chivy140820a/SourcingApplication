using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication6.Entity;

namespace WebApplication6.Configurations
{
    public class ManagerProductConfiguration : IEntityTypeConfiguration<ManagerProduct>
    {
        public void Configure(EntityTypeBuilder<ManagerProduct> builder)
        {
            builder.ToTable("ManagerProducts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.ProductStatusId);
            builder.HasOne(x => x.ProductStatus).WithMany(x => x.ManagerProducts).HasForeignKey(x => x.ProductStatusId);
        }
    }
}
