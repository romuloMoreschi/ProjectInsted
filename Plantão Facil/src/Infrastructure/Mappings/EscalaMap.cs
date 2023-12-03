using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class EscalaMap : IEntityTypeConfiguration<Escala>
{
    public void Configure(EntityTypeBuilder<Escala> builder)
    {
        builder.ToTable("Escalas");

        builder.HasKey(e => e.Id);

        builder
            .HasMany(e => e.Vagas)
            .WithOne(e => e.Escala)
            .HasForeignKey(e => e.EscalaId);

        builder
            .HasMany(e => e.Funcionarios)
            .WithMany(f => f.Escalas);
    }
}