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

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<CLContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated(); // Garante que a migração vai ser criada, caso não seja exibe um erro do porquê
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoManager, MedicoManager>();
        }

        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NovoClienteMappingProfile), typeof(AlteraClienteMappingProfile), typeof(NovoMedicoMappingProfile));
        }

        public static void FluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NovoCliente>, NovoClienteValidator>();
            services.AddTransient<IValidator<NovoEndereco>, NovoEnderecoValidator>();
            services.AddTransient<IValidator<AlteraCliente>, AlteraClienteValidator>();
            services.AddTransient<IValidator<NovoTelefone>, NovoTelefoneValidator>();
        }
    }
}