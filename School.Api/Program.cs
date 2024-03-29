using Microsoft.EntityFrameworkCore;
using School.Core;
using School.Core.MiddleWare;
using School.Infrustructure;
using School.Infrustructure.Data;
using School.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("Connect")));
#region Dependency Injectons
builder.Services.AddInfrustructureDependencies()
                .AddServiceDependencies()
                 .AddCoreDependencies();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
