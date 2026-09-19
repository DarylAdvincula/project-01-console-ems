using ConsoleEMS;
using ConsoleEMS.Dal;
using ConsoleEMS.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration
        .GetConnectionString("DefaultConnection");

    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<EmployeeService>();
builder.Services.AddTransient<App>();

using IHost host = builder.Build();
var app = host.Services.GetRequiredService<App>();

await app.Run();