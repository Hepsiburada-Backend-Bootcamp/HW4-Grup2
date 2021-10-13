using HW4_Grup4.Domain.Repositories;
using HW4_Grup4.Infrastructure.Context;
using HW4_Grup4.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HW4_Grup4.Infrastructure
{
    public static class InfraModuleExtensions
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMongoDbContext, MongoContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailMongoRepository, OrderDetailMongoRepository>();
            services.AddScoped<IUserMongoRepository, UserMongoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
