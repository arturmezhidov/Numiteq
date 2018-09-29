using Microsoft.Extensions.DependencyInjection;
using Numiteq.BusinessLogic.BusinessComponents;
using Numiteq.BusinessLogic.BusinessContracts;

namespace Numiteq.Common.DependencyInjection
{
    public static class BusinessLogicDependencyResolver
    {
        public static IServiceCollection AddBusinessComponents(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<INumberService, NumberService>();
            services.AddScoped<IMainServicesService, MainServicesService>();
            services.AddScoped<IStepService, StepService>();
            services.AddScoped<IExpertiseService, ExpertiseService>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IMessageEmailService, MessageEmailService>();
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}