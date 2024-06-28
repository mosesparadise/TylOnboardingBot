namespace TylOnboardingBot.Models;

public class OnboardingRequest
{
    public bool BankCustomer { get; set; }
    public string BusinessName { get; set; }
    public string BusinessRegistrationNumber { get; set; }
    public string Website { get; set; }
    public decimal AnnualTurnOver { get; set; }
}