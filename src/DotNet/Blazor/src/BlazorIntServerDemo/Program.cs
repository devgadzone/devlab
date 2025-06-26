using BlazorIntServerDemo.Components;
using BlazorIntServerDemo.Demos;
using BlazorServices.Services;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<IGreetingTransientService, GreetingService>();
builder.Services.AddScoped<IGreetingScopedService, GreetingService>();
builder.Services.AddSingleton<IGreetingSingletonService, GreetingService>();

builder.Services.TryAddCascadingValue(sp =>
{
    var model = new UserContext();
    model.UserId = Guid.NewGuid();
    model.Name = "User from Root component";
    var source = new CascadingValueSource<UserContext>(model, isFixed: false);
    
    return source;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
