using Asp.Versioning;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API
{
    public static class APIDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
