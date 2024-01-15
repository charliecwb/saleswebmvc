using System.Globalization;
using Microsoft.AspNetCore.Localization;
using SalesWebMvc.Configs;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDomainServices();

var app = builder.Build();
var enUS = new CultureInfo("en-US");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    using(var serviceScope = app.Services.CreateScope()) {
        var seed = serviceScope.ServiceProvider.GetService<SeedingService>();
        seed.Seed();
    }
}

app.UseRequestLocalization(new RequestLocalizationOptions{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS},
    SupportedUICultures = new List<CultureInfo> { enUS}
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
