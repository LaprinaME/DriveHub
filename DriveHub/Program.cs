using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using DriveHub.DataContext;
using DriveHub.Models;

var builder = WebApplication.CreateBuilder();


builder.Services.AddMvc();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Authorization");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Authorization");
    });


builder.Services.AddAuthorization();


string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DriveHubContext>(options => options.UseSqlServer(connection));


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseAuthentication();
app.UseAuthorization();


app.UseStaticFiles();

app.Run();