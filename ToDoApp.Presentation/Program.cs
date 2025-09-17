using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.UseCases.Categories;
using ToDoApp.Application.UseCases.Tasks;
using ToDoApp.Infrastructure.Persistence;
using ToDoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Configure Infrastructure Layer services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();