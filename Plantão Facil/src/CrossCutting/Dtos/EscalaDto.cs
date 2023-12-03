namespace CrossCutting.Dtos;

public class EscalaDto
{
    public long Id { get; set; }
    public DateTime DataInicial  { get; set; }
    public DateTime DataTermino { get; set; }
    public List<FuncionarioDto> Funcionarios { get; set; } = null!;
    public List<VagaDto> Vagas { get; set; } = null!;
}