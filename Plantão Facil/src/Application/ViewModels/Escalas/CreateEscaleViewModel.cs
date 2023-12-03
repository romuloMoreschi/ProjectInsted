using Domain.Entities;

namespace Application.ViewModels.Escalas;

public class CreateEscaleViewModel
{
    public DateTime DataInicial { get; set; }
    public DateTime DataTermino { get; set; }
    public long FuncionarioId { get; set; }
    public long VagaId { get; set; }
}
