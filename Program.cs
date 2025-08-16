using System.Data;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Identity;
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
builder.Services.AddAuthorization();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAssignmentservice, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRespository>();
builder.Services.AddScoped<IBulkJobService, BulkJobService>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//configure for connection with database
builder.Services.AddDbContext<ApplicationDbContext>(b =>
{
    var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
    b.UseNpgsql(connectionstring);
});

//configuration for hangfire
// #pragma warning disable CS0618 // Type or member is obsolete
// builder.Services.AddHangfire(config => config
//     .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//     .UseSimpleAssemblyNameTypeSerializer()
//     .UseRecommendedSerializerSettings()
//     .UsePostgreSqlStorage(builder.Configuration.GetConnectionString("DefaultConnection"))); 
// #pragma warning restore CS0618 // Type or member is obsolete



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<IdentityUser>();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .RequireAuthorization() .WithStaticAssets();

// app.UseHangfireDashboard(); // Enables the dashboard
// app.UseHangfireServer();    // Starts the background job server

app.Run();
