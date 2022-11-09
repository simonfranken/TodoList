using Microsoft.EntityFrameworkCore;
using TodoListApi.Data;
using TodoListApi.Error;
using TodoListApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Using MySql database as ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options
    .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 31))));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<ITodoEntryService, TodoEntryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Using ErrorHandlingMiddleware
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapControllers();

app.Run();
