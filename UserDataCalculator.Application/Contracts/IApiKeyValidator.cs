namespace UserDataCalculator.Application.Contracts;

public interface IApiKeyValidator
{
    bool IsValidApiKey(string apiKey);
}
