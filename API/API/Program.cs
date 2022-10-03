using API.Business.Interfaces;
using API.Business.Services;
using API.Infra.Context;
using API.Infra.Data;
using API.Infra.Interfaces;
using API.Infra.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var connection = builder.Configuration["ConnectionStrings:MSSQLConnectionString"];
        builder.Services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connection));

        builder.Services.AddScoped<ICadClienteRepository, CadClienteRepository>();
        builder.Services.AddScoped<ICadClienteService, CadClienteService>();
       



        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
       

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();                   

            }
            if (builder.Environment.IsDevelopment())
            {
            }
      

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}