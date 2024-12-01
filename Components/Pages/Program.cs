using BlazorApp.Components;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp.Components.Model;
using BlazorApp.Components.Bd;
using BlazorApp.Components.Service;


using CurrieTechnologies.Razor.SweetAlert2;
using Blazored.Modal;
using Blazored.Toast;
using Syncfusion.Blazor;
using static System.Runtime.InteropServices.JavaScript.JSType;


using Stripe;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();
    StripeConfiguration.ApiKey = "sk_test_51PFzTlBDnYXecvyeoYgpqSzW26PJhPllniMX8OmZhC69vdYuv9MC34xnicb7sIbwGGzmOj0fEHn4YgiMDJLkL5Fc00uKAQWUR4";

    builder.Services.AddDbContextFactory<AppDbContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("YourDatabaseConnection"), s => s.CommandTimeout(100)));
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<AoService>();
    builder.Services.AddScoped<MailService>();
    builder.Services.AddScoped<AdminService>();
    builder.Services.AddScoped<PasswordHandler>();
    builder.Services.AddSyncfusionBlazor();







    var app = builder.Build();


    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
      app.UseExceptionHandler("/Error", createScopeForErrors: true);
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.Run();

  }
}