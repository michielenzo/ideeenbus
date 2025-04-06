using ideeenbus.Models;
using ideeenbus.Repository;
using ideeenbus.Repository.Entity;

namespace ideeenbus.Service;

public class IdeeenService(IIdeeenStorage ideeenStorage) : IIdeeenService
{
    private readonly IIdeeenStorage _ideeenStorage = ideeenStorage;

    public async Task PersistAsync(Idee idee) {
        await _ideeenStorage.PersistAsync(IdeeEntity.FromModel(idee));
    }

    public async Task<List<Idee>> FetchAllAsync()
    {
       List<IdeeEntity> ideeEntities = await _ideeenStorage.FetchAllAsync();

       return [.. ideeEntities.Select(Idee.FromEntity)];
    }
}