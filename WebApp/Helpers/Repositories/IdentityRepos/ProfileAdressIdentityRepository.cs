using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.IdentityRepos;

public class ProfileAdressIdentityRepository : IdentityRepository<UserProfileAdressEntity>
{
    public ProfileAdressIdentityRepository(IdentityContext context) : base(context)
    {
    }
}
