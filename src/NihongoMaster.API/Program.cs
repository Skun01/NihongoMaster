using Microsoft.EntityFrameworkCore;
using NihongoMaster.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    
var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
