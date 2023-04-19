using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Helpers.Services;
using WebApp.Models.Contexts;
using WebApp.Models.Identities;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AdressIdentityRepository>();
builder.Services.AddScoped<ProfileIdentityRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SeedService>();



//Services for SQL
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.User.RequireUniqueEmail = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();



builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));







var app = builder.Build();



app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
