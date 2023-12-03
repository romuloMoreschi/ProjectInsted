namespace Domain.Entities;

public class Role : Base
{
    public string Nome { get; set; } = null!; // Exemplos: "Gerente", "Líder", "Funcionário"

    public List<Funcionario> Funcionarios { get; set; } = null!;

    public override bool Validate()
    {
        return true;
    }
}