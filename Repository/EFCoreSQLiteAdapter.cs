using ideeenbus.Repository.Entity;
using Microsoft.EntityFrameworkCore;
namespace ideeenbus.Repository;


public class EFCoreSQLiteAdapter(DatabaseContext databaseContext): IIdeeenStorage
{
    private readonly DatabaseContext _databaseContext = databaseContext;

    public async Task PersistAsync(IdeeEntity idee) {
        _databaseContext.Add(idee);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<IdeeEntity>> FetchAllAsync() {
        return await _databaseContext.Ideeen
             .Include(i => i.CategoryEntities)
             .OrderByDescending(i => i.CreatedAt)
             .ToListAsync();
    }
}