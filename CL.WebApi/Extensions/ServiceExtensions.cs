using System.Text;
using AutoMapper;
using CL.Core.Domains;
using CL.CoreShared.ModelViews;
using CL.Manager.Implementation;
using CL.Manager.Interfaces;
using CL.Manager.Interfaces.Services;
using CL.Manager.Mappings;
using CL.Manager.Validator;
using CL.WebApi.Context;
using CL.WebApi.Repository;
using CL.WebApi.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioManager, UsuarioManager>();
        }

        public static void UseAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovoClienteMappingProfile), 
                typeof(AlteraClienteMappingProfile), 
                typeof(NovoMedicoMappingProfile),
                typeof(UsuarioMappingProfile)
                );
        }

        public static void FluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IValidator<NovoCliente>, NovoClienteValidator>();
            services.AddTransient<IValidator<NovoEndereco>, NovoEnderecoValidator>();
            services.AddTransient<IValidator<AlteraCliente>, AlteraClienteValidator>();
            services.AddTransient<IValidator<NovoTelefone>, NovoTelefoneValidator>();
        }

        public static void AddJWTConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJWTService, JWTService>();

            var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);

            services.AddAuthentication(p => {
                p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(p =>
            {
                p.RequireHttpsMetadata = false;
                p.SaveToken = true;
                p.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JWT:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JWT:Audience").Value,
                    ValidateLifetime = true
                };
            });
        }
    }
}