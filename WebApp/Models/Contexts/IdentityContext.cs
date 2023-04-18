using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models.Contexts;

public class IdentityContext : IdentityDbContext
{
	public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
	{
	}

	public DbSet<UserProfileEntity> Profiles { get; set; }
	public DbSet<AdressEntity> Adresses { get; set; }
	public DbSet<UserProfileAdressEntity> ProfileAdresses { get; set;}
}
