using System.Data;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Service;
using TaskTracker.Service.Interface;
using TaskTracker.Repository;
using TaskTracker.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAssignmentservice, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRespository>();

builder.Services.AddDbContext<ApplicationDbContext>(b =>
{
    var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
    b.UseNpgsql(connectionstring);
});

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
