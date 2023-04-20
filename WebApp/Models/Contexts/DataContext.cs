using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public DbSet<ContactUserEntity> ContactUsers { get; set; }
	public DbSet<ContactInformationEntity> ContactInformations { get; set; }
}
