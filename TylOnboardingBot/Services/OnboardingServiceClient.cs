using TylOnboardingBot.Models;
using TylOnboardingBot.Models.Results;

namespace TylOnboardingBot.Services;

public class OnboardingServiceClient(HttpClient httpClient, ILogger<OnboardingServiceClient> logger) : IOnboardingServiceClient
{
    public async Task<Result<OnboardingResponse>> SubmitOnboardingRequest(OnboardingRequest request)
    {
        try
        {
            logger.LogInformation("Submitting onboarding request {OnboardingRequest}.", request);
            var response = await httpClient.PostAsJsonAsync("api/onboarding", request);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Failed to submit onboarding request. Status code: {statusCode}, Reason: {reasonPhrase}",
                    response.StatusCode, response.ReasonPhrase);
                return Result.Fail<OnboardingResponse>("Failed to submit onboarding request. Status code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            var onboardingResponse = await response.Content.ReadFromJsonAsync<OnboardingResponse>()
                                     ?? throw new Exception("Failed to deserialize onboarding response.");
            return Result.Success(onboardingResponse);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Failed to submit onboarding request.");
            return Result.Fail<OnboardingResponse>("Failed to submit onboarding request.");
        }
    }
}