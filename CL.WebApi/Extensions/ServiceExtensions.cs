using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Mappings;
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

        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoclienteMappingProfile), typeof(AlteraClienteMappingProfile));
        }

        public static void FluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NovoCliente>, NovoClienteValidator>();
            services.AddTransient<IValidator<AlteraCliente>, AlteraClienteValidator>();
        }
    }
}