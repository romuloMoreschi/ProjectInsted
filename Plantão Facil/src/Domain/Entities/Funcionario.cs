using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Funcionario : Base
{
    public string Nome { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public int Pontuacao { get; set; }
    public long EscalaId { get; set; }
    public Escala Escala { get; set; } = null!;
    public long RoleId { get; set; }
    public Role Role { get; set; } = null!;
    public long SituacaoId  { get; set; }
    public Situacao Situacao { get; set; } = null!;
    public long? VagaId { get; set; }
    public Vaga? Vaga { get; set; } = null!;

    public override bool Validate()
    {
        return true;
    }
}