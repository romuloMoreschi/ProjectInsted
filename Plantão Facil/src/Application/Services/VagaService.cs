using Application.Interfaces;
using AutoMapper;
using CrossCutting.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class VagaService : IVagaService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Vaga> _vagaRepository;
    
    public VagaService(IMapper mapper, IGenericRepository<Vaga> vagaRepository)
    {
        _mapper = mapper;
        _vagaRepository = vagaRepository;
    }
    
    public async Task<VagaDto> Create(VagaDto vagaDto)
    {
        var job = _mapper.Map<Vaga>(vagaDto);

        job.SituacaoId = 1;

        job.Validate();
        var jobCreated = await _vagaRepository.Create(job);

        return _mapper.Map<VagaDto>(jobCreated);
    }

    public async Task<VagaDto> Update(VagaDto vagaDto, long id)
    {
        var jobExists = await _vagaRepository.GetById(vagaDto.Id);

        if (jobExists == null)
            throw new Exception("Não existe nenhuma vaga com o id informado!");

        if (jobExists.Id != id) throw new Exception("O id informado não confere com o id da vaga!");

        var job = _mapper.Map<Vaga>(vagaDto);

        job.Validate();
        var jobUpdated = await _vagaRepository.Update(job);

        return _mapper.Map<VagaDto>(jobUpdated);
    }

    public async Task Remove(long id) => await _vagaRepository.Remove(id);

    public async Task<VagaDto> Get(long id)
    {
        var job = await _vagaRepository.GetById(id);

        return _mapper.Map<VagaDto>(job);
    }

    public async Task<List<VagaDto>> Get(int skip, int take)
    {
        var allJobs = await _vagaRepository.GetAll(skip, take);

        return _mapper.Map<List<VagaDto>>(allJobs);
    }
}