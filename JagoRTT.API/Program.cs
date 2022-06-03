using AutoMapper;
using JagoRTT.Application.AutoMapper;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.Services;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("MySQlConnectionString");
// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));
builder.Services.AddAutoMapper(typeof(DomainVMMapping), typeof(VMDomainMapping));
//IoC, DI
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IToolServices, ToolServices>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();


//private static void RegisterServices(IServiceCollection services)
//{
//    MyDependencyInjectionClassInInfraLayerForNextTime.RegisterServices(services);
//}
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
