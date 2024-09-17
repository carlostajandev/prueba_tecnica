using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PruebaBackend.Infrastructure.Persistence;
using PruebaTecnica_Back_end.Application.Services;
using PruebaTecnica_Back_end.Domain.Entities;
using PruebaTecnica_Back_end.Domain.Ports;
using PruebaTecnica_Back_end.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskManagementDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TaskService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole(Roles.Admin));
    options.AddPolicy("SupervisorPolicy", policy => policy.RequireRole(Roles.Supervisor));
    options.AddPolicy("EmployeePolicy", policy => policy.RequireRole(Roles.Employee));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("*")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


