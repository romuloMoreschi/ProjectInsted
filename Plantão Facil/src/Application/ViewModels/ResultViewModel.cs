namespace PontoServico.Application.ViewModels;

public class ResultViewModel
{
    public string? Message { get; set; }

    public dynamic? Data { get; set; }

    public bool ShouldSerializeData() => Data is not null;
}