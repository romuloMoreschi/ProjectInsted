using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Vagas;

public class UpdateJobViewModel
{
    [Required(ErrorMessage = "O id não pode ser vazio.")]
    public long Id { get; set; }

    [Required(ErrorMessage = "O horario não pode ser vazio.")]
    public DateTime Horario { get; set; }

    [Required(ErrorMessage = "A Função não pode ser vazia.")]
    public string Funcao { get; set; } = null!;

    [Required(ErrorMessage = "O numero de vagas não pode ser vazia.")]
    public int NumeroVagasDisponiveis { get; set; }

    public int SituacaoId { get; set; }

    public int EscalaId { get; set; }
}
