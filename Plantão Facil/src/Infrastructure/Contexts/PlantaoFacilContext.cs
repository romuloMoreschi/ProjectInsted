using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class PlantaoFacilContext : DbContext
{
    public PlantaoFacilContext() { }

    public PlantaoFacilContext(DbContextOptions<PlantaoFacilContext> options)
        : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PlantaoFacil;Trusted_Connection=True;MultipleActiveResultSets=true;");
    }
    
    public virtual required DbSet<Role> Roles { get; set; }
    
    public virtual required DbSet<Vaga> Vagas { get; set; }
    
    public virtual required DbSet<Escala> Escalas { get; set; }
    
    public virtual required DbSet<Situacao> Situacoes { get; set; }
    
    public virtual required DbSet<Funcionario> Funcionarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleMap());
        builder.ApplyConfiguration(new VagaMap());
        builder.ApplyConfiguration(new EscalaMap());
        builder.ApplyConfiguration(new SituacaoMap());
        builder.ApplyConfiguration(new FuncionarioMap());
    }
}