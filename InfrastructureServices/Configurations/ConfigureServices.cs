using Bussiness.Contracts.Services;
using InfrastructureServices.Services.Auth;
using InfrastructureServices.Services.Cryptography.AES;
using InfrastructureServices.Services.Cryptography.UTF8;
using InfrastructureServices.Services.Mail;
using InfrastructureServices.Services.OTP;
using InfrastructureServices.Services.SMS;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureServices.Configurations
{
    public static class ConfigureServices
    {
        #region Methods

        public static IServiceCollection InjectInfrastructureServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUTFService, UTFService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAesService, AesService>();
            services.AddScoped<IOTPService, OTPService>();
            services.AddScoped<ISMSService, SMSService>();

            return services;
        }

        #endregion
    }
}
