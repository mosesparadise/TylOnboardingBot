using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TylOnboardingBot.Models;

public record OnboardingRequest
{
    public bool BankCustomer { get; set; }
    
    [Required]
    [MinLength(2, ErrorMessage = "Business name must be at least 2 characters long")]
    [JsonPropertyName("fieldOne")]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    [MinLength(2, ErrorMessage = "Business registration number must be at least 2 characters long")]
    [JsonPropertyName("fieldThree")]
    public string BusinessRegistrationNumber { get; set; } = string.Empty;

    public string? Website { get; set; }

    [Required]
    [Range(1, 1000000, ErrorMessage = "Annual turnover must be between 1 and 1,000,000")]
    [JsonPropertyName("annualTurnOver")]
    public decimal AnnualTurnOver { get; set; }
}

public record OnboardingResponse
{
    [JsonPropertyName("recommended_products")]
    public List<OnboardingProduct> Products { get; set; } = new();
}

public record OnboardingProduct
{
    [JsonPropertyName("product_name")] public string Name { get; set; } = string.Empty;

    [JsonPropertyName("suitability")] public string Suitability { get; set; } = string.Empty;

    [JsonPropertyName("criteria")] public string Criteria { get; set; } = string.Empty;

    [JsonPropertyName("payment_type")] public string PaymentType { get; set; } = string.Empty;
}

public class OnboardingEventArgs(OnboardingRequest request, OnboardingResponse response) : EventArgs
{
    public OnboardingRequest Request { get; init; } = request;
    public OnboardingResponse Response { get; init; } = response;
}