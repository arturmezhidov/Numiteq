using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.DataContracts.Initialization;
using Numiteq.DataAccess.Initialization.Settings;
using Numiteq.DataAccess.Initialization.Users;
using Numiteq.DataAccess.SqlDataAccess;
using Numiteq.DataAccess.SqlDataAccess.Initialization;

namespace Numiteq.Common.DependencyInjection
{
    public static class DataAccessDependencyResolver
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            // Unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Storages
            services.AddSingleton<IInitializationDataStorage<Setting>, InitializationSettingStorage>();
            services.AddSingleton<IInitializationDataStorage<User>, InitializationUserStorage>();

            // Initializers
            services.AddSingleton<ITableInitializer, SettingsInitializer>();
            services.AddSingleton<ITableInitializer, UserInitializer>();
            services.AddSingleton<IDatabaseInitializer, DatabaseInitializer>();

            return services;
        }
    }
}
