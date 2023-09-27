using Nograd.Clients.CustomerApp.Models.Cart;
using Nograd.Clients.CustomerApp.Models.Product.Index;
using Nograd.ProductService.Queries.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IProductIndexMapper, ProductIndexMapper>();
builder.Services.AddScoped(SessionCart.GetCart);

builder.UseProductQueriesClient();

var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new { Controller = "Product", action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}",
    new { Controller = "Product", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}",
    new { Controller = "Product", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Product", action = "Index", productPage = 1 });
app.MapControllerRoute("empty", "", defaults: new { Controller = "Product", action = "Index" });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();


app.Run();