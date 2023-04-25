using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Helpers.Repositories.IdentityRepos;
using WebApp.Helpers.Services;
using WebApp.Models.Contexts;
using WebApp.Models.Identities;

var builder = WebApplication.CreateBuilder(args);

// Repositories
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AdressIdentityRepository>();
builder.Services.AddScoped<ProfileIdentityRepository>();
builder.Services.AddScoped<ContactUserRepository>();
builder.Services.AddScoped<ContactInformationRepository>();
builder.Services.AddScoped<ProfileAdressIdentityRepository>();
// Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ContactUsService>();
builder.Services.AddScoped<AdressService>();
builder.Services.AddScoped<AdminService>();



//Services for SQL
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.User.RequireUniqueEmail = false;
	x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<IdentityContext>()
.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();



builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
builder.Services.AddDbContext<DataContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("Data")));






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
