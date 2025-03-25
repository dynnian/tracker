using MudBlazor.Services;
using Tracker.Application;
using Tracker.Infrastructure;
using Tracker.Presentation.Components;
using Tracker.Presentation.Components.Account;

namespace Tracker.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add base services
        builder.Services.AddMudServices();
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add infrastructure layer
        builder.Services.AddInfrastructure(builder.Configuration, builder.Environment.IsProduction());

        // Add application layer
        builder.Services.AddApplication();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}