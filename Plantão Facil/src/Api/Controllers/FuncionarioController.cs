using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/employees/")]
public class FuncionarioController : ControllerBase
{
    private readonly IMapper _mapper;
    //private readonly IEscalaService _escalaService;
}
