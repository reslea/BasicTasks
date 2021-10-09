using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntityConfig
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(r => r.Users)
                .WithMany(u => u.Roles);

            builder.HasMany(r => r.Permissions)
                .WithMany(p => p.Roles);
        }
    }
}