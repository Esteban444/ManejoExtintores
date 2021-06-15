﻿using System.Collections.Generic;

namespace ManejoExtintores.Core.Modelos   
{
    public class Empresas
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Nit { get; set; }

        public ICollection<Empleados> Empleados { get; set; }
    }
}
