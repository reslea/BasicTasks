using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntityConfig
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.PermissionTypeId)
                .HasConversion<int>();

            builder.HasKey(p => p.PermissionTypeId);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(p => p.Roles)
                .WithMany(r => r.Permissions);
        }
    }
}