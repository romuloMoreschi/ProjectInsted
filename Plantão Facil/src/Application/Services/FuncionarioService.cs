using Application.Interfaces;
using AutoMapper;
using CrossCutting.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Funcionario> _funcionarioRepository;

    public FuncionarioService(IMapper mapper, IGenericRepository<Funcionario> funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
        _mapper = mapper;
    }

    public async Task<FuncionarioDto> Create(FuncionarioDto funcionatioDto)
    {
        var employee = _mapper.Map<Funcionario>(funcionatioDto);

        employee.Validate();
        var employeeCreated = await _funcionarioRepository.Create(employee);

        return _mapper.Map<FuncionarioDto>(employeeCreated);
    }

    public async Task<FuncionarioDto> Update(FuncionarioDto funcionatioDto, long id)
    {
        var employeeExists = await _funcionarioRepository.GetById(funcionatioDto.Id);

        if (employeeExists == null)
            throw new Exception("Não existe nenhum funcionario com o id informado!");

        if (employeeExists.Id != id) throw new Exception("O id informado não confere com o id do funcionario!");

        var employee = _mapper.Map<Funcionario>(funcionatioDto);

        employee.Validate();
        var employeeUpdated = await _funcionarioRepository.Update(employee);

        return _mapper.Map<FuncionarioDto>(employeeUpdated);
    }

    public async Task Remove(long id) => await _funcionarioRepository.Remove(id);

    public async Task<FuncionarioDto> Get(long id)
    {
        var employee = await _funcionarioRepository.GetById(id);

        return _mapper.Map<FuncionarioDto>(employee);
    }

    public async Task<List<FuncionarioDto>> Get(int skip, int take)
    {
        var allEmployees = await _funcionarioRepository.GetAll(skip, take);

        return _mapper.Map<List<FuncionarioDto>>(allEmployees);
    }
}
