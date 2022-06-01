using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JagoRTT.IoC
{
    public class DI
    {
        public static void Services(IServiceCollection services)
        {

            //Repo
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //Application: Service
            //services.AddScoped<ICompanyServices, CompanyServices>();
            //services.AddScoped<IToolServices, ToolServices>();
            //services.AddScoped<IRentalServices, RentalServices>();
            //services.AddScoped<IEmployeeServices, EmployeeServices>();

            services.AddDbContext<ApplicationContext>();

        }
    }
}
