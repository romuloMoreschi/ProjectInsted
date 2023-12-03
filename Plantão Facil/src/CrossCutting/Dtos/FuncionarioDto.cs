namespace CrossCutting.Dtos;

public class FuncionarioDto
{
    public long Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public int Pontuacao { get; set; }

    public VagaDto? Vaga { get; set; }

    public int SituacaoId { get; set; }
}