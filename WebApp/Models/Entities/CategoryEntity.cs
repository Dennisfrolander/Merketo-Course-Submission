using System.Runtime.CompilerServices;
using WebApp.Models.ViewModels;

namespace WebApp.Models.Entities;

public class CategoryEntity
{
	public int Id { get; set; }
	public string CategoryName { get; set; } = null!;
	public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>(); 

	public static implicit operator CategoryViewModel(CategoryEntity entity)
	{
		return new CategoryViewModel
		{
			Id = entity.Id,
			Name = entity.CategoryName
		};
	}

}
