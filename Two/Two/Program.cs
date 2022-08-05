using System.Globalization;
using DataAccsessLayer.Context;
using DataAccsessLayer.UnitOfWork;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RZ_TOW_LANG.BAL.Business;
using Two.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IBusinessNazar, BusinessNazar>();
builder.Services.AddTransient<IBusinessCountry, BuisinessCountry>();
builder.Services.AddSqlServer<DataContextClass>(builder.Configuration.GetConnectionString("sqlserver"));
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var SupportedCulture = new List<System.Globalization.CultureInfo>()
    {
        new CultureInfo("fa-IR"),
        new CultureInfo("en-US")
    };
    options.SupportedCultures = SupportedCulture;
    options.SupportedUICultures = SupportedCulture;
    options.DefaultRequestCulture = new RequestCulture("fa", "fa-IR");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
await app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<DataContextClass>().Database.MigrateAsync();
if (app.Environment.IsDevelopment())
{
    // UseDeveloperExceptionPage() -> using Microsoft.AspNetCore.Builder;
    app.UseDeveloperExceptionPage();
}
else
{
    // UseExceptionHandler() -> using Microsoft.AspNetCore.Builder;
    app.UseExceptionHandler("/Errors/Error");

    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios,
    // see https://aka.ms/aspnetcore-hsts
    // UseHsts() -> using Microsoft.AspNetCore.Builder; 
    app.UseHsts();
}
app.UseHttpsRedirection();
app.CustomStaticFiles();

app.UseAuthorization();
app.CustomCookiMiddlerware();
app.MapRazorPages();
app.Run();