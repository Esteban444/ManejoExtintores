﻿
namespace ManejoExtintores.Core.DTOs 
{
    public class EmpleadoBase
    {
        public int IdEmpleados { get; set; }
        public int? IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
