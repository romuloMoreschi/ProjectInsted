﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings;

public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("Funcionarios");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(f => f.Sexo)
            .IsRequired() 
            .HasMaxLength(1); 

        builder.Property(f => f.Pontuacao)
            .IsRequired()
            .HasDefaultValue(1000);

        builder.HasOne(f => f.Role).WithMany(x => x.Funcionarios).HasForeignKey(f => f.RoleId);

        builder.HasOne(f => f.Situacao).WithMany().HasForeignKey(f => f.SituacaoId);

        builder.HasMany(f => f.Escalas).WithMany(e => e.Funcionarios);
    }
}