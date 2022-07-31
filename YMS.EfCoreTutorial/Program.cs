using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using YMS.EfCoreTutorial.Contexts;
using YMS.EfCoreTutorial.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.HttpOnly = true;
    opt.Cookie.Name = "YMSCookie";
    opt.LoginPath = new PathString("/Auth/Login");
    opt.LogoutPath = new PathString("/Auth/Logout");
    opt.AccessDeniedPath = new PathString("/Auth/AccessDenied");
});


builder.Services.AddDbContext<YMSContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});



builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>
    {
        new EmployeeProfile()
    });
});

// configure request response pipeline
var app = builder.Build();

// npm aracılığı ile 
// libman aracılığı
// static file 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(opt =>
{
    opt.MapDefaultControllerRoute();
});

app.Run();
