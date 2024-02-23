using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CleanArchitectureWorkshop.Presentation.Blazor;
using UnityWithBackendWorkshop.Infrastructure;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new ApiClient (
                                    builder.HostEnvironment.BaseAddress,
                                    sp.GetRequiredService<HttpClient>()));
builder.Services.AddMudServices();

await builder.Build().RunAsync();
