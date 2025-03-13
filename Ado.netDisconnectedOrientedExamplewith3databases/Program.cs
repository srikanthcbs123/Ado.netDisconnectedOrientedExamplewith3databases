using Ado.netDisconnectedOrientedExample.Interfaces;
using Ado.netDisconnectedOrientedExample.Repositories;
using Ado.netDisconnectedOrientedExample.Services;
using Ado.netDisconnectedOrientedExamplewith3databases.Connection;
using Ado.netDisconnectedOrientedExamplewith3databases.Interfaces;
using Ado.netDisconnectedOrientedExamplewith3databases.Repositories;
using Ado.netDisconnectedOrientedExamplewith3databases.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IDepartmentRepository, DepertmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentServices>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService,OrderServices>();
builder.Services.AddSingleton<IDatabaseConnectionFactory, ConnectionFactory>();
//it will create only one object that object is used for entire application.
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
