using API_To_Do_List.Cliente.FiltrosRequest;
using API_To_Do_List.Infra.Interfaces;
using API_To_Do_List.Infra.PersistirDados.Contexto;
using API_To_Do_List.Infra.Repositorio;
using API_To_Do_List.Service.Servico.Interfaca;
using API_To_Do_List.Service.Servico.Repositorio;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(option => {
        option.Filters.Add(typeof(FiltroValidacao));
        option.Filters.Add(typeof(FiltroExcecao));
    });

builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<ITarefaServico, TarefaServico>();

var connectionString = builder.Configuration.GetConnectionString("ToDoListCs");
builder.Services.AddDbContext<ApiContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
