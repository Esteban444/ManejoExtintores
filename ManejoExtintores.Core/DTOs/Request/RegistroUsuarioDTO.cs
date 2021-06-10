﻿using System.ComponentModel.DataAnnotations;


namespace ManejoExtintores.Core.DTOs.Request
{
    public class RegistroUsuarioDTO
    {
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo Email no puede ir vacío.")]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Password no puede ir vacío.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
        public string Discriminador { get; set; } 
        public string ClientURI { get; set; }
    }
}
