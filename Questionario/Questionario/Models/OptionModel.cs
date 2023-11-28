namespace Questionario.Models;

public class OptionModel
{
    public int Id { get; set; }
    public string Answer { get; set; } = null!;
    public bool IsCorrect { get; set; }
}
