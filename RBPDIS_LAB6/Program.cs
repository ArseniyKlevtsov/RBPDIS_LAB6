
using Microsoft.EntityFrameworkCore;
using RBPDIS_LAB6.Models;
using System.Text.Json.Serialization;

namespace RBPDIS_LAB6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<RailwayTrafficContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers()
                // это можно удалить
                // оно не используется
                // это нужно для игнорирования циклов при серриализации
                // т.е. если  Train содержит ссылку на TrainType, который содержит список Train, то такое будет
                // серриализоваться вечно если барть колеекцию с Trains.include(t => t.TrainType)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.MapControllers();


            app.Run();
        }
    }
}