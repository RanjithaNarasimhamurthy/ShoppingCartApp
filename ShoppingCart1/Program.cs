using ShoppingCartLibrary; 
using ShoppingCart1.Controllers;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=thoughtclan;Integrated Security=True;";
builder.Services.AddSqlServer<ShoppingDbContext>(constr);

//configure dependency injection for dataaccess layer

builder.Services.AddTransient<IProductDataAccess,ProductDataAccessLayer>();
builder.Services.AddTransient<ICartDataAccess, CartDataAccessLayer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
