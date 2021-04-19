using EFSamples.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSamples.EntityConfigurations
{
    public class VisitorConfiguration : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(_ => _.Name).IsUnique();
        }
    }
}