namespace PontoServico.Application.ViewModels;

public class Responses
{
    public static ResultViewModel ApplicationErrorMessage(string message)
    {
        return new ResultViewModel
        {
            Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente: \n" + message
        };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
        return new ResultViewModel
        {
            Message = message
        };
    }

    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModel
        {
            Message = message,
            Data = errors
        };
    }
    public static ResultViewModel PreconditionFailed(string message)
    {
        return new ResultViewModel
        {
            Message = message
        };
    }

    public static ResultViewModel UnauthorizedErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "A combinação de login e senha está incorreta!"
        };
    }
}
