using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class VagaMap : IEntityTypeConfiguration<Vaga>
{
    public void Configure(EntityTypeBuilder<Vaga> builder)
    {
        builder.ToTable("Vagas");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Horario).IsRequired();

        builder.Property(v => v.Funcao).IsRequired().HasMaxLength(255);

        builder.Property(v => v.NumeroVagasDisponiveis).IsRequired();

        builder.HasOne(v => v.Situacao).WithMany().HasForeignKey(v => v.SituacaoId);

        builder.HasOne(v => v.Escala).WithMany(x => x.Vagas).HasForeignKey(x => x.EscalaId); 
    }
}




