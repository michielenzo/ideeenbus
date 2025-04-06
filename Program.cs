using ideeenbus.Repository;
using ideeenbus.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IIdeeenService, IdeeenService>();
builder.Services.AddScoped<IIdeeenStorage, EFCoreSQLiteAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
.WithStaticAssets();

app.Run();
