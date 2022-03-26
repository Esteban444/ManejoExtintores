using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using System.Linq.Expressions;


namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        public HandlingExtinguishersDbContext DatabaseContext { get; set; }

        public BaseRepository(HandlingExtinguishersDbContext context) 
        {
            DatabaseContext = context;
        }

        public virtual IQueryable<T> GetAll() 
        {
            var entityset = DatabaseContext.Set<T>();
            return entityset.AsQueryable();
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate)  
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public async Task Add(T entity)
        {
            await DatabaseContext.AddAsync(entity);
            await DatabaseContext.SaveChangesAsync();

        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) 
        {
            return GetAll().Where(predicate);
        }
        public async Task Update(T entity) 
        {
            var updateT = entity.GetType().GetProperty("TimeMod");
            if (updateT != null) entity.GetType().GetProperty("TimeMod")?.SetValue(entity, DateTime.Now);
            DatabaseContext.Update(entity);
            await DatabaseContext.SaveChangesAsync();

        }

        public async Task Delete(T entity) 
        {
            var updateDele = entity.GetType().GetProperty("IsDeleted");
            if (updateDele != null)
            {
                entity.GetType().GetProperty("IsDeleted")?.SetValue(entity, true);

                var update = entity.GetType().GetProperty("TimeDele");
                if (update != null) entity.GetType().GetProperty("TimeDele")?.SetValue(entity, DateTime.Now);
                DatabaseContext.Update(entity);
            }
            else
            {
                DatabaseContext.Remove(entity);
            }
            await DatabaseContext.SaveChangesAsync();
        }

        public Task AddRange(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(List<T> entity)
        {
            throw new NotImplementedException();
        }
    }
}
