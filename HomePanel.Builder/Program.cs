using HomePanel.Builder;
using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using HomePanel.Builder.Components;
using HomePanel.Builder.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<HomePanelBuilderConfiguration>().Configure<IConfiguration>((options, config) =>
    {
        options.EsphomeConfigPath = config.GetValue<string>("HOMEPANEL_BUILDER_ESPHOME_CONFIG")
            ?? throw new InvalidOperationException("ESPHome config path is not configured");
    });

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
    .AddMemoryCache()
    .AddScoped<ServerPanelDesignsProvider>()
    .AddScoped<IPanelDesignsProvider, CachingPanelDesignsProvider>()
    .AddScoped<ServerDeviceListProvider>()
    .AddScoped<IDeviceListProvider, CachingDeviceListProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HomePanel.Builder.Client._Imports).Assembly);

app.MapPost("/api/designs", (IPanelDesignsProvider provider, NewPanelInfo newPanelInfo) => provider.AddNewPanel(newPanelInfo));
app.MapGet("/api/designs", (IPanelDesignsProvider provider) => provider.GetDesignInfos());
app.MapGet("/api/devices", (IDeviceListProvider provider) => provider.GetDeviceList());

app.Run();
