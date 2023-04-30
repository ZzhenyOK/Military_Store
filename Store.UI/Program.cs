using Microsoft.EntityFrameworkCore;
using Store.DAL.DataContext;
using Store.DAL.Repositories;
using Store.DAL.Repositories.Contracts;
using Store.BLL.Services;
using Store.BLL.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Store.BLL.DTO;
using Store.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Identity.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using StackExchange.Redis;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbmilitaryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders().AddRoles<IdentityRole<int>>()
  .AddEntityFrameworkStores<DbmilitaryContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Login";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

builder.Services.AddScoped<IService<CategoryDTO>, CategoryService>();
builder.Services.AddScoped<IService<CartDTO>, CartService>();
builder.Services.AddScoped<IService<HistoryDTO>, HistoryService>();
builder.Services.AddScoped<IService<ProductDTO>, ProductService>();
builder.Services.AddScoped<IService<ProductImagesDTO>, ProductImagesService>();

builder.Services.AddTransient(typeof(IGenericRepository<Category>), typeof(GenericRepository<CategoryRepository>));
builder.Services.AddTransient(typeof(IGenericRepository<Cart>), typeof(GenericRepository<CartRepository>));
builder.Services.AddTransient(typeof(IGenericRepository<History>), typeof(GenericRepository<HistoryRepository>));
builder.Services.AddTransient(typeof(IGenericRepository<Product>), typeof(GenericRepository<ProductRepository>));
builder.Services.AddTransient(typeof(IGenericRepository<ProductImages>), typeof(GenericRepository<ProductImagesRepository>));


