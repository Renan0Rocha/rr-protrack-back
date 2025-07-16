using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using rr_protrack_back.DataContext;
using rr_protrack_back.Services;
using rr_protrack_back.DataContexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Config connection database
var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<AppDbContext>(options =>
    options
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .UseSnakeCaseNamingConvention()
);

builder.Services.AddScoped<VendedorService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<ProgramaService>();
builder.Services.AddScoped<InsercaoService>();
builder.Services.AddScoped<OrdemBlocoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ContratoService>();
builder.Services.AddScoped<OrdemBlocoContratoService>();



var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();