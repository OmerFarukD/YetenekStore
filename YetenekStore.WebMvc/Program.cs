using Microsoft.AspNetCore.Identity;
using YetenekStore.Models.Entities;
using YetenekStore.Repository.Contexts;
using YetenekStore.Repository.Repositories.Abstracts;
using YetenekStore.Repository.Repositories.Concretes;
using YetenekStore.Service.Abstracts;
using YetenekStore.Service.Concretes;
using YetenekStore.Service.Helpers.Cloudinary;
using YetenekStore.Service.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("Cloudinary"));



builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BaseDbContext>();


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
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();