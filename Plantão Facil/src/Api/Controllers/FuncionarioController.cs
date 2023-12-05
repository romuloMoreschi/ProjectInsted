using Application.Interfaces;
using AutoMapper;
using CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;
using PontoServico.Application.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("/api/employees/")]
public class FuncionarioController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFuncionarioService _funcionarioService;

    public FuncionarioController(IMapper mapper, IFuncionarioService funcionarioService)
    {
        _mapper = mapper;
        _funcionarioService = funcionarioService;
    }

    //[HttpPost]
    //[Route("create")]
    //public async Task<IActionResult> Create([FromBody] CreateEmployeViewModel jobViewModel)
    //{
    //    var employeDto = _mapper.Map<FuncionarioDto>(jobViewModel);

    //    var employeCreated = await _funcionarioService.Create(employeDto);

    //    return Ok(new ResultViewModel
    //    {
    //        Message = "Funcionario cadastrado com sucesso!",
    //        Data = employeCreated
    //    });
    //}

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        var allEmployees = await _funcionarioService.Get(skip, take);

        return Ok(new ResultViewModel
        {
            Message = "Funcionarios encontrados com sucesso!",
            Data = allEmployees
        });
    }
}
