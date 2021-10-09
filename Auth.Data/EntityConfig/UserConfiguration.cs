using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.Property(u => u.Salt)
                .IsRequired()
                .HasMaxLength(512 / 8);
            
            builder.Property(u => u.HashedPassword)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(u => u.Roles)
                .WithMany(r => r.Users);
        }
    }
}
