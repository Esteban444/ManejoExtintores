using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.DTOs.Request
{
    public class AutenticacionExternaDTO 
    {
        public string Proveedor { get; set; } 
        public string IdToken { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; } 
        public string Email { get; set; }
    }
}
