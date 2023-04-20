using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.DataRepos;

public class ContactInformationRepository : DataRepository<ContactInformationEntity>
{
    public ContactInformationRepository(DataContext context) : base(context)
    {
    }
}
