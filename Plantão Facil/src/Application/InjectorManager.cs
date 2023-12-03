using Application.Interfaces;
using Application.Services;
using Application.ViewModels.Escalas;
using Application.ViewModels.Vagas;
using AutoMapper;
using CrossCutting.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class InjectorManager
{
    public static void ConfigureServices(IServiceCollection services)
    {
        ConfigureAutoMapper(services);

        RegisterRepositories(services);

        RegisterServices(services);
    }

    private static void ConfigureAutoMapper(IServiceCollection services)
    {
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Vaga, VagaDto>().ReverseMap();
            cfg.CreateMap<CreateJobViewModel, VagaDto>().ReverseMap();

            cfg.CreateMap<Escala, EscalaDto>().ReverseMap();
            cfg.CreateMap<CreateEscaleViewModel, EscalaDto>().ReverseMap();

        });

        services.AddSingleton(autoMapperConfig.CreateMapper());
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IVagaService, VagaService>();
        services.AddScoped<IEscalaService, EscalaService>();
    }
}