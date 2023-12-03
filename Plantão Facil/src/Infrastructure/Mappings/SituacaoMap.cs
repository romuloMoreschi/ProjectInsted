using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class SituacaoMap : IEntityTypeConfiguration<Situacao>
{
    public void Configure(EntityTypeBuilder<Situacao> builder)
    {
        builder.ToTable("Situacoes"); 

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nome).IsRequired().HasMaxLength(255);
    }
}

