using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Contexts;

namespace WebApp.Helpers.Repositories.IdentityRepos;

public abstract class IdentityRepository<TEntity> where TEntity : class
{
    protected readonly IdentityContext _context;

    public IdentityRepository(IdentityContext context)
    {
        _context = context;
    }

	public virtual async Task<TEntity> CreateAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();

			return entity!;
		}
		catch { return null!; }

	}


	public virtual async Task<TEntity> UpdateAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();

			return entity!;
		}
		catch { return null!; }
	}

	public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			return entity!;
		}
		catch { return null!; }
	}

	public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			return await _context.Set<TEntity>().ToListAsync();
		}
		catch { return null!; }
	}

	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var items = await _context.Set<TEntity>().Where(expression).ToListAsync();
			return items;
		}
		catch { return null!; }
	}

	public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
			if (entity != null)
			{
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
		catch { return false!; }

	}
}
