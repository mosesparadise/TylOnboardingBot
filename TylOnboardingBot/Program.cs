using MudBlazor.Services;
using TylOnboardingBot.Components;
using TylOnboardingBot.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder
    .Services
    .AddMudServices()
    // .AddScoped<IOnboardingServiceClient, NullOnboardingServiceClient>()
    .AddHttpClient<IOnboardingServiceClient, OnboardingServiceClient>((sp, client) =>
    {
        var configuration = sp.GetRequiredService<IConfiguration>();
        var baseUri = configuration["OnboardingService:BaseUrl"];
        if (string.IsNullOrWhiteSpace(baseUri))
            throw new InvalidOperationException("OnboardingService:BaseUrl is required.");
        client.BaseAddress = new Uri(baseUri);
    })
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();