using System.Globalization;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using TylOnboardingBot.Models;

namespace TylOnboardingBot.Components.Common;

public partial class OnboardingComponent
{
    private readonly OnboardingRequest _formRequest = new();
    private readonly CultureInfo _englishCulture = CultureInfo.GetCultureInfo("en-GB");

    private bool _isSubmitting;

    [Parameter] public EventCallback<OnboardingEventArgs> OnRequestSubmitted { get; set; }

    private async Task SubmitAsync()
    {
        try
        {
            _isSubmitting = true;

            // Call the service to submit the form
            var result = await OnboardingServiceClient.SubmitOnboardingRequest(_formRequest);
            if (!result.IsSuccess)
            {
                await DialogService.ShowMessageBox("Error", "Failed to submit the form. Please try again.");
                Snackbar.Add("Failed: " + result.Error, Severity.Error);
                return;
            }

            await DialogService.ShowMessageBox("Success", "Form submitted successfully.");
            await OnRequestSubmitted.InvokeAsync(new OnboardingEventArgs(_formRequest, result.Value!));
        }
        finally
        {
            _isSubmitting = false;
        }
    }
}