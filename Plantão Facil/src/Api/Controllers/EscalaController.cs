using Application.Interfaces;
using Application.Services;
using Application.ViewModels.Escalas;
using Application.ViewModels.Vagas;
using AutoMapper;
using CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;
using PontoServico.Application.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("/api/escales/")]
public class EscalaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEscalaService _escalaService;

    public EscalaController(IMapper mapper, IEscalaService escalaService)
    {
        _mapper = mapper;
        _escalaService = escalaService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateEscaleViewModel jobViewModel)
    {
        var escaleDto = _mapper.Map<EscalaDto>(jobViewModel);

        var escaleCreated = await _escalaService.Create(escaleDto);

        return Ok(new ResultViewModel
        {
            Message = "Escala cadastrada com sucesso!",
            Data = escaleCreated
        });
    }

    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        var allEscales = await _escalaService.Get(skip, take);

        return Ok(new ResultViewModel
        {
            Message = "Escalas encontradas com sucesso!",
            Data = allEscales
        });
    }
}
