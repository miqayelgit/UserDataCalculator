using Microsoft.Extensions.DependencyInjection;
using UserDataCalculator.Application.Contracts;
using UserDataCalculator.Application.Services.Calculations;
using UserDataCalculator.Application.Services.Validators;

namespace UserDataCalculator.Application.Extensions;

public static class UserDataExtensions
{
    public static IServiceCollection AddUserDataServices(this IServiceCollection services)
    {
        services.AddScoped<IUserDataCalculation, UserDataCalculation>();
        services.AddScoped<IApiKeyValidator, ApiKeyValidator>();

        return services;
    }
}
