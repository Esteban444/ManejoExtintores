using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoExtintores.Core.DTOs.Responce
{
    public class AuthRespuestaDTO
    {
        public bool AuthExitosa { get; set; } 
        public string MensajeError { get; set; } 
        public string Token { get; set; }
        public bool Verificacion { get; set; } 
        public string Proveedor { get; set; } 
    }
}
