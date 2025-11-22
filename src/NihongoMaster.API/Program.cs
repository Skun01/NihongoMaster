using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NihongoMaster.Application.Interfaces;
using NihongoMaster.Application.Interfaces.Services;
using NihongoMaster.Application.Services;
using NihongoMaster.Application.Validators;
using NihongoMaster.Infrastructure.Data;
using NihongoMaster.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
