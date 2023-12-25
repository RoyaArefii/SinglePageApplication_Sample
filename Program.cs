using Microsoft.EntityFrameworkCore;
using SinglePageApplication.ApplicationService.Contracts;
using SinglePageApplication.ApplicationService.Service;
using SinglePageApplication.Models.Contracts;
using SinglePageApplication.Models.Service;
using SinglePageApplication.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

IServiceCollection serviceCollection = builder.Services.AddDbContext<OnlineshopDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
        ));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPersonAppService, PersonAppService>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

