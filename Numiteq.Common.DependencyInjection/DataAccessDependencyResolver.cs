﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;
using Numiteq.DataAccess.Initialization;
using Numiteq.DataAccess.SqlDataAccess;

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

            services.AddSingleton<IInitializationDataStorage, InitializationDataStorage>();
            services.AddSingleton<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}