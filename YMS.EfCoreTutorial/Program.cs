using AutoMapper;
using YMS.EfCoreTutorial.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
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

app.UseEndpoints(opt =>
{
    opt.MapDefaultControllerRoute();
});

app.Run();
