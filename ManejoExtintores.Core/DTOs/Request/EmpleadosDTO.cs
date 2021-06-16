
namespace ManejoExtintores.Core.DTOs 
{
    public class EmpleadosDTO : EmpleadoBase
    {
        public int IdEmpleados { get; set; }
        public EmpresaDTO Empresa { get; set; } 
       
    }
}
