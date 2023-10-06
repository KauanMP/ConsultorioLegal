using CL.WebApi.Context;
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
    }
}