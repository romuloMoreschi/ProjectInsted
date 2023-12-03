using CrossCutting.Dtos;

namespace Application.Interfaces;

public interface IVagaService
{
    Task<VagaDto> Create(VagaDto vagaDto);
    Task<VagaDto> Update(VagaDto vagaDto);
    Task Remove(long id);
    Task<VagaDto> Get(long id);
    Task<List<VagaDto>> Get(int skip, int take);
}