using Application.Interfaces;
using AutoMapper;
using CrossCutting.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Services;

public class EscalaService : IEscalaService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Escala> _escalaRepository;

    public EscalaService(IMapper mapper, IGenericRepository<Escala> escalaRepository)
    {
        _escalaRepository = escalaRepository;
        _mapper = mapper;
    }

    public async Task<EscalaDto> Create(EscalaDto escalaDto)
    {
        var escale = _mapper.Map<Escala>(escalaDto);

        escale.Validate();
        var escaleCreated = await _escalaRepository.Create(escale);

        return _mapper.Map<EscalaDto>(escaleCreated);
    }

    public async Task<EscalaDto> Update(EscalaDto escalaDto, long id)
    {
        var escaleExists = await _escalaRepository.GetById(escalaDto.Id);

        if (escaleExists == null)
            throw new Exception("Não existe nenhuma escala com o id informado!");

        if (escaleExists.Id != id) throw new Exception("O id informado não confere com o id da escala!");

        var escale = _mapper.Map<Escala>(escalaDto);

        escale.Validate();
        var escalaUpdated = await _escalaRepository.Update(escale);

        return _mapper.Map<EscalaDto>(escalaUpdated);
    }

    public async Task Remove(long id) => await _escalaRepository.Remove(id);

    public async Task<EscalaDto> Get(long id)
    {
        var escale = await _escalaRepository.GetById(id);

        return _mapper.Map<EscalaDto>(escale);
    }

    public async Task<List<EscalaDto>> Get(int skip, int take)
    {
        static IQueryable<Escala> includes(IQueryable<Escala> query) =>
            query.Include(x => x.Vagas).Include(x => x.Funcionarios);

        var allEscales = await _escalaRepository.GetAll(skip, take, includes);

        return _mapper.Map<List<EscalaDto>>(allEscales);
    }
}