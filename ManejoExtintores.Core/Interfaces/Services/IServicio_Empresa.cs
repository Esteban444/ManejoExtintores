using ManejoExtintores.Core.DTOs;
using ManejoExtintores.Core.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.Interfaces 
{
    public interface IServicio_Empresa
    {
        IEnumerable<EmpresaDTO> GetEmpresas();
        EmpresaDTO GetEmpresa(int id);
        Task<EmpresaBase> CrearEmpresa(EmpresaBase empresa);
        Task<EmpresaBase> ActualizarEmpresa(int id,EmpresaBase empresa);
        Task<EmpresaDTO> EliminarEmpresa(int id); 
    }
}