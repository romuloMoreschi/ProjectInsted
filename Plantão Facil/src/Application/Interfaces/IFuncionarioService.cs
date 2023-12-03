using CrossCutting.Dtos;

namespace Application.Interfaces;

public interface IFuncionarioService
{
    Task<FuncionarioDto> Create(FuncionarioDto funcionarioDto);
    Task<FuncionarioDto> Update(FuncionarioDto funcionarioDto, long id);
    Task Remove(long id);
    Task<FuncionarioDto> Get(long id);
    Task<List<FuncionarioDto>> Get(int skip, int take);
}
