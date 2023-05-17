using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.DataRepos;

public class ProductTagRepository : DataRepository<ProductTagEntity>
{
	public ProductTagRepository(DataContext context) : base(context)
	{
	}

}
