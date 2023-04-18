using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.IdentityRepos;

public class ProfileIdentityRepository : IdentityRepository<UserProfileEntity>
{
    public ProfileIdentityRepository(IdentityContext context) : base(context)
    {
    }
}
