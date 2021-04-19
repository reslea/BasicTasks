using EFSamples.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSamples.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(_ => _.Author)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(_ => _.Visitor)
                .WithMany(_ => _.TakenBooks)
                .HasForeignKey(_ => _.VisitorId);
        }
    }
}