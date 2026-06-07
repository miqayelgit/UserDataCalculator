using Microsoft.Extensions.Configuration;
using UserDataCalculator.Application.Contracts;

namespace UserDataCalculator.Application.Services.Validators;

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly string _validApiKey;
    public ApiKeyValidator(IConfiguration config)
    {
        _validApiKey = config["ApiKey"]!;
    }

    public bool IsValidApiKey(string apiKey)
    {
        return apiKey == _validApiKey;
    }
}
