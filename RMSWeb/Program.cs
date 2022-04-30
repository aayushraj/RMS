using RMS.Repository;
using RMS.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RMSWeb.Data;
using RMSWeb.Areas.Identity.Data;
using System.Data;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("RMSWebContextConnection");
//builder.Services.AddDbContext<RMSWebContext>(options =>
//    options.UseSqlServer(connectionString));builder.Services.AddDefaultIdentity<RMSWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<RMSWebContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRepositoryService();
builder.Services.AddService();


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
    name: "default",
    pattern: "{controller=TenantInfo}/{action=Index}/{id?}");

app.Run();
