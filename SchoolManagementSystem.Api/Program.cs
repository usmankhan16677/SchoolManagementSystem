using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolManagementSystem.Application.Mappings;
using SchoolManagementSystem.Application.Services;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

//  Configure Database Connection
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//  Register AutoMapper 
services.AddAutoMapper(typeof(MappingProfile));

//  Register Repositories for Dependency Injection
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//  Register Services for Dependency Injection
services.AddScoped<AdminService>();
services.AddScoped<TeacherService>();
services.AddScoped<StudentService>();

//  Add Controllers and API Behavior Configuration
services.AddControllers();

//  Enable Swagger for API Documentation
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Management API", Version = "v1" });
});

var app = builder.Build();

//  Configure Middleware & Routing
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
