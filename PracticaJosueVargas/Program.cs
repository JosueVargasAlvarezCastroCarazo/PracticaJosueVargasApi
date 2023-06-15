using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaJosueVargas.Models;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


        var CnnStringBuilder = new SqlConnectionStringBuilder(
          builder.Configuration.GetConnectionString("CNNSTR")
          );

        string cnnStr = CnnStringBuilder.ConnectionString;

        builder.Services.AddDbContext<materialadministrationContext>(options => options.UseSqlServer(cnnStr));

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

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}