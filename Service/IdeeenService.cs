using ideeenbus.Models;
using ideeenbus.Repository;
using ideeenbus.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ideeenbus.Service;

public class IdeeenService(DatabaseContext databaseContext) : IIdeeenService
{
    private readonly DatabaseContext _databaseContext = databaseContext;

    public async Task PersistAsync(Idee idee) {
        _databaseContext.Add(IdeeEntity.FromModel(idee));
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<Idee>> FetchAllAsync()
    {
       List<IdeeEntity> ideeEntities = await _databaseContext.Ideeen
            .Include(i => i.CategoryEntities)
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync();

       return [.. ideeEntities.Select(Idee.FromEntity)];
    }
}