using Contracts.Models;
using Contracts.Requests;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using FluentValidation;
using ImageUploadService.Validation;
using Service;

namespace ImageUploadService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IValidator<AddLeadImageRequest>, AddLeadImageValidator>();
        builder.Services.AddScoped<IValidator<DeleteLeadImageRequest>, DeleteLeadImageValidator>();

        builder.Services.AddScoped<IImageUploadLogic, ImageUploadLogic>();
        builder.Services.AddDbContextPool<LeadContext>(options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("LeadConnectionString")
        ));
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}