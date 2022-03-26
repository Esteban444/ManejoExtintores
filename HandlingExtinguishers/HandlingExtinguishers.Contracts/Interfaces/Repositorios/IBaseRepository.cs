using System.Linq.Expressions;


namespace HandlingExtinguishers.Contracts.Interfaces.Repositorios
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();  
        T GetSingle(Expression<Func<T, bool>> predicate);  
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task Add(T entity);  
        Task AddRange(List<T> entity);
        Task Update(T entity);
        Task UpdateRange(List<T> entity);
        Task Delete(T entity);
        Task DeleteRange(List<T> entity);
    }
}
