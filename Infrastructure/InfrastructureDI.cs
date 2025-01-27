using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnection>(provider => new SqlConnection(connectionString));

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IEmployeesRepository, EmployeeRepository>();
            services.AddScoped<IOrdersRepository, OrderRepository>();
            services.AddScoped<IProductsRepository, ProductRepository>();
            services.AddScoped<IShippersRepository, ShipperRepository>();

            return services;
        }
    }
}
