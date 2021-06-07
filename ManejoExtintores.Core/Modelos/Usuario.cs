using Microsoft.AspNetCore.Identity;

namespace ManejoExtintores.Core.Modelos   
{
    public class Usuario: IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; } 
    }
}
