using Microsoft.EntityFrameworkCore;
using HalloDocRepository.Implementation;
using HalloDocRepository.Interfaces;
using HalloDocServices.Interfaces;
using HalloDocServices.Implementation;
using System;
using HalloDocRepository.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();    
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IPatientloginRepository,PatientLoginRepository>();
builder.Services.AddScoped<IPatientLoginServices,PatientLoginServices>();
builder.Services.AddScoped<IPatientRequestService,PatientRequestService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



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

app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=AdminDashboard}/{id?}");

app.Run();
