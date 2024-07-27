using eclipseworksDesafio.Application.Interfaces;
using eclipseworksDesafio.Application.Services;
using eclipseworksDesafio.Core.Interfaces;
using eclipseworksDesafio.Infrastructure.Data.Context;
using eclipseworksDesafio.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);


// Configurar o contexto do banco de dados
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString));
// Configurar o contexto do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Nome da sua API",
        Version = "v1",
        Description = "Descrição da sua API",
        Contact = new OpenApiContact
        {
            Name = "Desafio ",
            Email = "equipe@exemplo.com",
            Url = new Uri("https://exemplo.com")
        }
    });

    // Inclui os comentários XML para a documentação do Swagger (opcional)
    //string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});
// Adicionar serviços da camada Application

builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();
builder.Services.AddScoped(typeof(ProjetoService));
builder.Services.AddScoped<TarefaService>();
builder.Services.AddScoped<ComentarioService>();


// Adicionar serviços da camada Core
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();
builder.Services.AddScoped<IHistoricoTarefasRepository, HistoricoTarefasRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


var app = builder.Build();
//SWAGEGR
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome da sua API V1");
    c.RoutePrefix = "swagger";
    c.DocExpansion(DocExpansion.None); // Opções de expansão da documentação no Swagger UI
});
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
