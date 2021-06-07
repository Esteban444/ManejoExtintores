using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicio_Empresa
    {
        IEnumerable<Empresa> GetEmpresas();
        Empresa GetEmpresa(int id);
        Task CrearEmpresa(Empresa empresa);
        Task<bool> ActualizarEmpresa(Empresa empresa);
        Task<bool> EliminarEmpresa(int id); 
    }
}