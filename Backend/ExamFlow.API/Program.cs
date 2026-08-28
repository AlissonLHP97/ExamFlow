using ExamFlow.API.Configurations;
using ExamFlow.API.Repositories;
using ExamFlow.API.Services;
using RestWithASPNET10alisson.Configurations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<ExameRepository>();
builder.Services.AddScoped<ExameService>();

builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<PacienteService>();

builder.Services.AddScoped<SolicitacaoExameRepository>();
builder.Services.AddScoped<SolicitacaoExameService>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();