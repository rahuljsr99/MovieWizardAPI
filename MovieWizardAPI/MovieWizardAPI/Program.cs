    using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieWizardAPI.Data;
using MovieWizardAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<UsersDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<DirectorDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<MovieDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<MovieRevenueDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<MovieBudgetDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<MoviePriceDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));

builder.Services.AddDbContext<ActorDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("MovieWizardConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(options => options
    .AllowAnyOrigin()  // Allow requests from any origin
    .AllowAnyMethod()   // Allow any HTTP method (GET, POST, PUT, etc.)
    .AllowAnyHeader()); // Allow any request header
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

