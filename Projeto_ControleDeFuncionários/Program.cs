using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configura o Mysql
builder.Services.AddDbContext<banco_de_dados>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
        ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
   
    //configura o swagger + UI 
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto_ControleDeFuncionários v1");
        options.RoutePrefix = "swagger";

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
