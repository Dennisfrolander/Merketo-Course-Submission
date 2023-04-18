using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Contexts;

public class IdentityContext : IdentityDbContext
{
	public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
	{
	}
}
