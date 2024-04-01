namespace WebApplication.ApiKeyValidation
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
