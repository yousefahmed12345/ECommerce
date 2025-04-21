using ECommerce.Data;
using ECommerce.Data.Cart;
using ECommerce.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(x => ShoppingCart.GetShoppingCart(x));
builder.Services.AddSession();
builder.Services.AddScoped<IOrderServices, OrderServices>();

builder.Services.AddDbContext<EcommerceDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
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
app.UseSession();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");


AppDbInitializer.Seed(app);
app.Run();
