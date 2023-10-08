using CL.Core.Domains;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Validator;
using CL.WebApi.Context;
using CL.WebApi.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CL.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            services.AddDbContext<CLContext>(o =>
             o.UseMySql(connectionString, serverVersion));

        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
        }
    }
}