using CrossCutting.Dtos;

namespace Application.Interfaces;

public interface IEscalaService
{        
    Task<EscalaDto> Create(EscalaDto escalaDto);
    Task<EscalaDto> Update(EscalaDto escalaDto, long id);
    Task Remove(long id);
    Task<EscalaDto> Get(long id);
    Task<List<EscalaDto>> Get(int skip, int take);
}