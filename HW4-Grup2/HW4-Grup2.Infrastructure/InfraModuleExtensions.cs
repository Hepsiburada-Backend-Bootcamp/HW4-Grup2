using HW4_Grup2.Domain.Repositories;
using HW4_Grup2.Infrastructure.Context;
using HW4_Grup2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HW4_Grup2.Infrastructure
{
    public static class InfraModuleExtensions
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))); 
            services.AddDbContext<DapperContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMongoDbContext, MongoContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderMongoRepository, OrderMongoRepository>();
            services.AddScoped<IUserMongoRepository, UserMongoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDapperRepository, UserDapperRepository>();
            services.AddScoped<IProductDapperRepository, ProductDapperRepository>();
            services.AddScoped<IOrderDapperRepository, OrderDapperRepository>();

            return services;
        }
    }
}
