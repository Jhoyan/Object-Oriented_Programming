using Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

string enderecoDoServidorWebAPI = "https://localhost:7031";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(enderecoDoServidorWebAPI)
});

await builder.Build().RunAsync();
