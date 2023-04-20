using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.DataRepos;

public class ContactUserRepository : DataRepository<ContactUserEntity>
{
    public ContactUserRepository(DataContext context) : base(context)
    {
    }
}
