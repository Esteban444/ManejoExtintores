using System.Linq.Expressions;


namespace HandlingExtinguishers.Contracts.Interfaces.Repositorios
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Consultas();
        T ConsultaPorId(Expression<Func<T, bool>> predicado);
        IQueryable<T> ConsultaPor(Expression<Func<T, bool>> predicado);
        Task Crear(T modelo);
        Task Actualizar(T modelo);
        Task Eliminar(T modelo);
    }
}
