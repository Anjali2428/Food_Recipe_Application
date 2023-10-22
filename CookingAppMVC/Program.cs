using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using CookingAppMVC.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<gdshDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("gdshDbContext") ?? throw new InvalidOperationException("Connection string 'gdshDbContext' not found.")));

// Configuration for authentication and authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LoginReg/Login"; // Redirect to login page if not authenticated
        options.AccessDeniedPath = "/Home/Error"; // Redirect to access denied page
    });

// Add DbContext

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginReg}/{action=Login}/{id?}");

app.Run();
