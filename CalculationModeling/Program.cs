using CalculationModeling.Data;
using CalculationModeling.Services;
using CalculationModeling.Data;
using CalculationModeling.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=heat_exchange.db"));

builder.Services.AddScoped<IHeatExchangeCalculator, HeatExchangeCalculator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculations}/{action=Index}/{id?}");

app.Run();
