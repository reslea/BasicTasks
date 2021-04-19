using EFSamples.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSamples.EntityConfigurations
{
    public class BookPriceConfiguration : IEntityTypeConfiguration<BookPrice>
    {
        public void Configure(EntityTypeBuilder<BookPrice> builder)
        {
            builder.ToTable("Prices");

            builder.HasKey(_ => _.Id);
            
            builder
                .HasOne(_ => _.Book)
                .WithOne();
        }
    }
}