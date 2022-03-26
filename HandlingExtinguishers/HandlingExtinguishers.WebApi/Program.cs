using FluentValidation.AspNetCore;
using HandlingExtinguishers.DTO.Models;
using HandlingExtinguishers.Infrastructure;
using HandlingExtinguishers.WebApi.Configurations;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDependenceInjectionConfiguration();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<HandlingExtinguishersDbContext>().AddDefaultTokenProviders();

builder.Services.AddSwaggerConfiguration();


#region Cors
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("api",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
#endregion

builder.Services.DatabaseConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HandlingExtinguishers.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseExceptionHandler(HandlingExceptions.UseAPIErrorHandling);

app.UseCors("api");

app.UseRouting();

///app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
