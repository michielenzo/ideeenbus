using ideeenbus.Models;
using ideeenbus.Repository.Entity;
using ideeenbus.Repository;

namespace ideeenbus.Service;

public interface IIdeeenService
{
    public Task PersistAsync(Idee idee);
    public Task<List<Idee>> FetchAllAsync();
}

