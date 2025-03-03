using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShipCreator1.Data;
using ShipCreator1.Models;

var builder = WebApplication.CreateBuilder(args);
// Set up SQLite in Development generate the db file to access sqlite (rider knows to connect to sqlite and generate the db file
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ShipCreator1Context>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ShipCreator1Context")));
}
else
{
    builder.Services.AddDbContext<ShipCreator1Context>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionShipCreator1Context")));
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//seds program on startup if no data in db:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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