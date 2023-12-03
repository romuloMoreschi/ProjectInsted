namespace CrossCutting.Dtos;

public class VagaDto
{
    public long Id { get; set; }
    public DateTime Horario { get; set; }
    public string Funcao { get; set; } = null!;
    public int NumeroVagasDisponiveis { get; set; }
    public int SituacaoId  { get; set; }
}