using JagoRTT.Application.AutoMapper;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.Services;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("MySQlConnectionString");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 29))));
builder.Services.AddAutoMapper(typeof(DomainVMMapping), typeof(VMDomainMapping));//add the package for AddAutoMapper

//IoC, DI
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IToolServices, ToolServices>();
builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<IRentalServices, RentalServices>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
