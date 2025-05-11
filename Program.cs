using Microsoft.OpenApi.Models;
using Pagamentos.Services;
using Pagamentos.Services.Interface;
using Serilog;
using Serilog.Formatting.Compact;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
Directory.CreateDirectory(logFolder);

// Lendo o appsettings
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
string pathAppsettings = "appsettings.json";

if (env == "Development")
{
    pathAppsettings = "appsettings.Development.json";
}

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(pathAppsettings)
    .Build();

// Configura��o do Serilog
var connectionString = config["stringConexao"];
Console.WriteLine($"Connection String: {connectionString}"); // Para depura��o

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(new CompactJsonFormatter(),
                   Path.Combine(logFolder, "logs.json"),
                   retainedFileCountLimit: 10,
                   rollingInterval: RollingInterval.Day)
    .WriteTo.MySQL(connectionString,
                   "Logs", // Nome da tabela
                   restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Habilitando o uso do Serilog.
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICartaoService, CartaoService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>(); // Certifique-se de ter esse servi�o

// Configura��o do DbContext
builder.Services.AddDbContext<PagamentoDbContext>(options =>
    options.UseMySql(connectionString,
                     new MySqlServerVersion(new Version(8, 0, 21)))); // Altere a vers�o conforme necess�rio

// Configurar o Swagger
#region Habilitando o uso do Swagger (OPENAPI)

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gerenciamento da API de Pagamentos...",
        Version = "v1",
        Description = $@"<h3>Gerenciamento <b>da API de pagamentos</b></h3>
                        <p>
                            Documenta��o da API de pagamentos....
                        </p>",
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});
#endregion
var app = builder.Build();

// Habilitar o middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = ""; //habilitar a p�gina inicial da API ser a doc.
    c.DocumentTitle = "API de Pagamentos - API V1";
});
// Configure o pipeline de requisi��es
app.UseAuthorization();
app.MapControllers();

app.Run();
