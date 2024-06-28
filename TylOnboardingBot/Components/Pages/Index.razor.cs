using Microsoft.AspNetCore.Components;
using TylOnboardingBot.Models;

namespace TylOnboardingBot.Components.Pages;

public partial class Index : ComponentBase
{
    [Inject] private ILogger<Index> Logger { get; set; } = default!;

    private OnboardingEventArgs? _onboardingEventArgs;

    private bool CanShowRecommendation => _onboardingEventArgs != null && _onboardingEventArgs.Response.Products.Any();

    private void HandleOnboardingRequestSubmitted(OnboardingEventArgs onboardingEventArgs)
    {
        Logger.LogInformation("Onboarding request {@Request}", onboardingEventArgs.Request);
        Logger.LogInformation("Onboarding response {@Response}", onboardingEventArgs.Response);

        _onboardingEventArgs = onboardingEventArgs;

        StateHasChanged();
    }
}