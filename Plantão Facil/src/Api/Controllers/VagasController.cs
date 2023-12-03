using Application.Interfaces;
using Application.ViewModels.Vagas;
using AutoMapper;
using CrossCutting.Dtos;
using Microsoft.AspNetCore.Mvc;
using PontoServico.Application.ViewModels;

namespace Api.Controllers;

[ApiController]
[Route("/api/jobs/")]
public class VagasController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IVagaService _vagasService;

    public VagasController(IMapper mapper, IVagaService vagasService)
    {
        _mapper = mapper;
        _vagasService = vagasService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] CreateJobViewModel jobViewModel)
    {
        var jobDto = _mapper.Map<VagaDto>(jobViewModel);

        var jobCreated = await _vagasService.Create(jobDto);

        return Ok(new ResultViewModel
        {
            Message = "Vaga cadastrada com sucesso!",
            Data = jobCreated
        });
    }

    [HttpPut]
    [Route("update/")]
    public async Task<IActionResult> Update([FromBody] UpdateJobViewModel jobViewModel)
    {
        var jobDto = _mapper.Map<VagaDto>(jobViewModel);

        var jobUpdated = await _vagasService.Update(jobDto);

        return Ok(new ResultViewModel
        {
            Message = "Marca atualizada com sucesso!",
            Data = jobUpdated
        });
    }

    [HttpDelete]
    [Route("remove/{id}")]
    public async Task<IActionResult> Remove(long id)
    {
        await _vagasService.Remove(id);

        return Ok(new ResultViewModel
        {
            Message = "Vaga removida com sucesso!",
            Data = null
        });
    }

    [HttpGet]
    [Route("get/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var job = await _vagasService.Get(id);

        if (job == null)
            return Ok(new ResultViewModel
            {
                Message = "Nenhuma vaga foi encontrado com o ID informado.",
                Data = job
            });

        return Ok(new ResultViewModel
        {
            Message = "Vaga encontrada com sucesso!",
            Data = job
        });
    }


    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> Get(int skip = 0, int take = 10)
    {
        var allJobs = await _vagasService.Get(skip, take);

        if (!allJobs.Any())
            return StatusCode(404, new ResultViewModel
            {
                Message = "Nenhuma vaga cadastrada foi encontrada!",
            });

        return Ok(new ResultViewModel
        {
            Message = "Vagas encontradas com sucesso!",
            Data = allJobs
        });
    }
}
