using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Nome).IsRequired().HasMaxLength(255);

        builder.HasMany(r => r.Funcionarios).WithOne(f => f.Role).HasForeignKey(f => f.RoleId);
    }
}

