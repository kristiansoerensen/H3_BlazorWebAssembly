using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using BlazorWebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7043/api/") });
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
