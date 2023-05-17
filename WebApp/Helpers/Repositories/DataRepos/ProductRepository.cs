using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories.DataRepos;

public class ProductRepository : DataRepository<ProductEntity>
{
	public ProductRepository(DataContext context) : base(context)
	{
	}

	public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		try
		{
			var entity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(predicate);
			return entity!;
		}

		catch { return null!; }
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
	{
		try
		{
			return await _context.Products.Include(x => x.Category).ToListAsync();
		}
		catch { return null!; }
		
	}

	public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		try
		{
			return await _context.Products.Include(x => x.Category).Where(expression).ToListAsync();
		}
		catch { return null!; }
	}

	public  async Task<ProductEntity> GetWithTagsAsync(Expression<Func<ProductEntity, bool>> predicate)
	{
		try
		{
			var entity = await _context.Products.Include(x => x.Category).Include(x => x.Tags).FirstOrDefaultAsync(predicate);
			return entity!;
		}

		catch { return null!; }
	}

	public async Task<IEnumerable<ProductEntity>> GetAllWithTagsAsync()
	{
		try
		{
			return await _context.Products.Include(x => x.Tags).ThenInclude(x => x.Tag).Include(x => x.Category).ToListAsync();
		}
		catch { return null!; }
	}
	public async Task<IEnumerable<ProductEntity>> GetAllWithTagsAsync(Expression<Func<ProductEntity, bool>> expression)
	{
		try
		{
			return await _context.Products.Include(x => x.Tags).ThenInclude(x => x.Tag).Include(x => x.Category).Where(expression).ToListAsync();
		}
		catch { return null!; }
	}

}
