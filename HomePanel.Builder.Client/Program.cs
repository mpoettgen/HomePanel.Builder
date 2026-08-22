using HomePanel.Builder.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPanelDesignsProvider, ClientPanelDesignsProvider>();
builder.Services.AddScoped<IDeviceListProvider, ClientDeviceListProvider>();
builder.Services.AddScoped<IconUrlProvider>();
builder.Services.AddScoped<IIconService, ClientIconService>();

await builder.Build().RunAsync();
