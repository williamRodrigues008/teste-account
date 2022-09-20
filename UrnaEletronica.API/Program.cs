using Microsoft.EntityFrameworkCore;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;
using UrnaEletronica.API.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UrnaEletronicaContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"));
});

var permiteOrigemEspecifica = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: permiteOrigemEspecifica,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7208");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICandidato, CandidatoRepository>();
builder.Services.AddScoped<IVoto, VotoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin());   
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


app.Run();