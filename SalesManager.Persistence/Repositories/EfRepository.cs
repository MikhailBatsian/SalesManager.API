using Ardalis.Specification.EntityFrameworkCore;
using SalesManager.Domain.Interfaces.Repositories;

namespace SalesManager.Persistence.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public EfRepository(SalesManagerDbContext dbContext) : base(dbContext)
    {
    }
}