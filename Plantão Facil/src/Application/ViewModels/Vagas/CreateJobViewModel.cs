using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Vagas;

public class CreateJobViewModel
{
    [Required(ErrorMessage = "O horario não pode ser vazio.")]
    public DateTime Horario { get; set; }

    [Required(ErrorMessage = "A Função não pode ser vazia.")]
    public string Funcao { get; set; } = null!;

    [Required(ErrorMessage = "O numero de vagas não pode ser vazia.")]
    public int NumeroVagasDisponiveis { get; set; }
}
