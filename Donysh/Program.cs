using Infrastructure.Configuration;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.PortableExecutable;
using Application.Configuration;
using Donysh.Tools;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
;
builder.Services.AddSingleton<Generator>();
//*************************CustomConfiguration
builder.Services.InfrastructureServices(builder.Configuration);
builder.Services.ApplicationServices(builder.Configuration);
//*************************CustomConfiguration

//Identity
builder.Services.Configure<IdentityOptions>(option =>
{
    option.User.RequireUniqueEmail = true;
    option.Password.RequireNonAlphanumeric = true;
    option.Password.RequiredLength = 6;
    option.SignIn.RequireConfirmedEmail = true;
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;
    option.Lockout.MaxFailedAccessAttempts = 4;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    option.User.RequireUniqueEmail = true;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequiredUniqueChars = 1;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
});
builder.Services.ConfigureApplicationCookie(cooke =>
{
    cooke.ExpireTimeSpan = TimeSpan.FromDays(30);
    cooke.LoginPath = "/Account/SignIn";
    cooke.AccessDeniedPath = "/";
    cooke.SlidingExpiration = true;
});
//Identity

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
