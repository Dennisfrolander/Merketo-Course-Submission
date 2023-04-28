using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.IdentityRepos;

public class ProfileAdressRepository : IdentityRepository<UserProfileAdressEntity>
{
	public ProfileAdressRepository(IdentityContext context) : base(context)
	{
	}
}
