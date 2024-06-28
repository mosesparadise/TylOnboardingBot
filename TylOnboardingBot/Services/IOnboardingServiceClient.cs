using TylOnboardingBot.Models;
using TylOnboardingBot.Models.Results;

namespace TylOnboardingBot.Services;

public interface IOnboardingServiceClient
{
    Task<Result<OnboardingResponse>> SubmitOnboardingRequest(OnboardingRequest request);
}

public class NullOnboardingServiceClient : IOnboardingServiceClient
{
    public Task<Result<OnboardingResponse>> SubmitOnboardingRequest(OnboardingRequest request)
    {
        var dummyResponse = new OnboardingResponse();
        dummyResponse.Products.Add(new OnboardingProduct
            { Name = "Dummy Product", Suitability = "Dummy Suitability", Criteria = "Dummy Criteria", PaymentType = "Dummy Payment Type" });

        return Task.FromResult(Result.Success(dummyResponse));
    }
}