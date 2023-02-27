using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using ShopCenter.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString
    ("ShopCenterDbContextConnection") ?? throw new InvalidOperationException
    ("Connection string 'ShopDbContext' not found.");
builder.Services.AddDbContext<ShopDbContext>(options =>
        options.UseSqlServer(builder.Configuration["Connectionstrings:ShopCenterDbContextConnection"]));


builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ShopDbContext>();


builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });



builder.Services.AddControllers();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();
