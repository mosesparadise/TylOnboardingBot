using Microsoft.AspNetCore.Components;
using TylOnboardingBot.Models;

namespace TylOnboardingBot.Components.Common;

public partial class ShowRecommendation : ComponentBase
{
    [Parameter] public OnboardingEventArgs? OnboardingEventArgs { get; set; }
    private List<OnboardingProduct>? _products;
    private bool _loading;

    protected override Task OnInitializedAsync()
    {
        _loading = true;
        if (OnboardingEventArgs != null)
        {
            _products = OnboardingEventArgs.Response.Products;
        }

        _loading = false;
        return Task.CompletedTask;
    }
}