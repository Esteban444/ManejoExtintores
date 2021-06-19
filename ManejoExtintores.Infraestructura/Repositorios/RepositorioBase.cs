using ManejoExtintores.Core.Interfaces;
using ManejoExtintores.Infraestructura.Data; 
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ManejoExtintores.Infraestructura.Repositorios 
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class, new()
    {
        public ManejoExtintoresContext DatabaseContext { get; set; } 

        public RepositorioBase(ManejoExtintoresContext context)
        {
            DatabaseContext = context;
        }

        public  IQueryable<T> Consultas()
        {
            var modeloset = DatabaseContext.Set<T>();
            return   modeloset.AsQueryable();
        }
        public T ConsultaPorId(Expression<Func<T, bool>> predicado)
        {
            return  Consultas().FirstOrDefault(predicado);
        }

        public async Task Crear(T modelo)
        {
            await DatabaseContext.AddAsync(modelo);
            await DatabaseContext.SaveChangesAsync();
           
        }

        public  IQueryable<T> ConsultaPor(Expression<Func<T, bool>> predicado)
        {
            return Consultas().Where(predicado);
        }
        public async Task Actualizar(T modelo )
        {
            var actualizarT = modelo.GetType().GetProperty("TiempoModi");
            if (actualizarT != null) modelo.GetType().GetProperty("TiempoModi").SetValue(modelo, DateTime.Now);
             DatabaseContext.Update(modelo);
            await DatabaseContext.SaveChangesAsync();
            
        }

        public async Task Eliminar(T modelo)
        {
            var actulizarEli = modelo.GetType().GetProperty("IsDeleted");
            if(actulizarEli != null)
            {
                modelo.GetType().GetProperty("IsDeleted").SetValue(modelo, true);

                var actualizar = modelo.GetType().GetProperty("TiempoEli");
                if (actualizar != null) modelo.GetType().GetProperty("TiempoEli").SetValue(modelo, DateTime.Now);
                DatabaseContext.Update(modelo);
            }
            else
            {
                DatabaseContext.Remove(modelo);
            }
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
