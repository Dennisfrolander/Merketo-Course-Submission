using System.Linq.Expressions;
using WebApp.Helpers.Repositories.DataRepos;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services;

public class CategoryService
{
	private readonly CategoryRepository _categoryRepository;

	public CategoryService(CategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
	{
		try
		{
			List<CategoryViewModel> categories = new();
			var categoryEntities = await _categoryRepository.GetAllAsync();
			foreach (var entity in categoryEntities)
			{
				categories.Add(entity);
			}

			return categories;
		}
		catch { return null!;}
	}
}
