namespace Domain.Entities;

public class Escala : Base
{
    public DateTime DataInicial  { get; set; }
    
    public DateTime DataTermino { get; set; }
    public List<Funcionario> Funcionarios { get; set; } = null!;
    public List<Vaga> Vagas { get; set; } = null!;
    
    public override bool Validate()
    {
        return true;
    }
}