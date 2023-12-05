using Application;
using Infrastructure.Contexts;
using PontoServico.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

InjectorManager.ConfigureServices(builder.Services);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        corsPolicyBuilder => corsPolicyBuilder.WithOrigins("*")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddDbContext<PlantaoFacilContext>(ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();