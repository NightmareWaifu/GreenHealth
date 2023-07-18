using GreenHealthWebsite.Data;
using GreenHealthWebsite.Models.Customer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connctionString = builder.Services.AddDbContext<ALLDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GreenHealthConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    //pattern: "{controller=MedicineOrder}/{action=Order}/{id?}");
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
