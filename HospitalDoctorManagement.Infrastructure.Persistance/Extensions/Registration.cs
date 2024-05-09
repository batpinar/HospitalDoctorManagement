using HospitalDoctorManagement.Api.Core.Application.Interfaces.Repositories;
using HospitalDoctorManagement.Infrastructure.Persistance.Context;
using HospitalDoctorManagement.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDoctorManagement.Infrastructure.Persistance.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalDoctorDbContext>(config =>
            {
                var connStr = configuration["HospitalDbConnectionString"].ToString();
                config.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();

            return services;
        }
    }
}
