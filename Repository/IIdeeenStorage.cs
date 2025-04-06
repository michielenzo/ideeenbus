using ideeenbus.Repository.Entity;

namespace ideeenbus.Repository;

public interface IIdeeenStorage
{
    public Task PersistAsync(IdeeEntity idee);

    public Task<List<IdeeEntity>> FetchAllAsync();
}

