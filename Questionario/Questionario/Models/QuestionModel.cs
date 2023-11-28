namespace Questionario.Models;

public class QuestionModel
{
    public int Id { get; set; }
    public string Question { get; set; } = null!;
    public List<OptionModel> Options { get; set; } = null!;
}
