using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.DataRepos;

public class TagRepository : DataRepository<TagEntity>
{
	public TagRepository(DataContext context) : base(context)
	{
	}
}
