global using NubexGold.Client.Data;
global using NubexGold.Client.Models.Repository;
global using NubexGold.Client.Services;
global using NubexGold.Shared;
global using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor;
using Microsoft.AspNetCore.Hosting;
using MudBlazor.Services;
using NubexGold.Client.Areas.Identity;
using NubexGold.Client.Models.Profiles;
using Microsoft.Extensions.DependencyInjection;
using NubexGold.Client.Services.UserCartServices;



//var ports = ":7155/";
var builder = WebApplication.CreateBuilder(args);
var baseAddress = "https://localhost/";

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

baseAddress = builder.Configuration.GetValue<string>("BaseUrl");
//baseAddress = 
builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
}
);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<ISellerService, SellerService >();
builder.Services.AddScoped<IConditionService, ConditionService>();
builder.Services.AddScoped<IUserCartService,UserCartService>();
builder.Services.AddAutoMapper(typeof(ProductProfile));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IConditionRepository, ConditionRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IConditionService, IConditionService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger.json", "NubexGold.Client v1"));
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NubexGold.Client v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseStaticFiles();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
