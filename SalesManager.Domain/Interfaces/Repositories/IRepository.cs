using Ardalis.Specification;

namespace SalesManager.Domain.Interfaces.Repositories;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}
