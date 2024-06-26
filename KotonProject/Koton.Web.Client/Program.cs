using Koton.Entities.Context;
using Koton.Shared;
using Koton.Web.Client.Extensions;
using Koton.Web.Client.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Configure DbContext with SQL Server
builder.Services.AddDbContext<KotonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBasketService, BasketService>();    
builder.Services.AddScoped<IOrderService, OrderService>();    
builder.Services.AddTransient<HttpClientAuthenticationDelegate>();
builder.Services.AddHttpClient("kotonWebApi", x =>
{

    x.BaseAddress = new Uri("https://localhost:7117/api/");
}).AddHttpMessageHandler<HttpClientAuthenticationDelegate>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<SharedIdentity>();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

});
builder.Services.AddMemoryCache();
    
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Login}/{id?}");

app.Run();


