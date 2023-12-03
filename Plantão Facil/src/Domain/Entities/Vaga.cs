namespace Domain.Entities;

public class Vaga : Base
{   
    public DateTime Horario { get; set; }
    public string Funcao { get; set; } = null!;
    public int NumeroVagasDisponiveis { get; set; }
    public long SituacaoId  { get; set; }
    public Situacao Situacao { get; set; } = null!;
    public long EscalaId { get; set; }
    public Escala Escala { get; set; } = null!;
    public List<Funcionario> Funcionarios { get; set; } = null!;

    public override bool Validate()
    {
        return true;
    }
}