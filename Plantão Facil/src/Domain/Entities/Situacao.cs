namespace Domain.Entities;

public class Situacao : Base
{
    public string Nome { get; set; } = null!;
    
    public override bool Validate()
    {
        return true;
    }
}