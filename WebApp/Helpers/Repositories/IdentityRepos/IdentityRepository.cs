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

        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();

        return entity!;
    }


    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {

        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();

        return entity!;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return entity!;
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
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
}
