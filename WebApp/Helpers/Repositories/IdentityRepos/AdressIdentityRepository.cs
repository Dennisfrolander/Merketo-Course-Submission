using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.IdentityRepos;

public class AdressIdentityRepository : IdentityRepository<AdressEntity>
{
    public AdressIdentityRepository(IdentityContext context) : base(context)
    {
    }
}
