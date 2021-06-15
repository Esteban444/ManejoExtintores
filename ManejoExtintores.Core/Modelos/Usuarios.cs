using Microsoft.AspNetCore.Identity;
using System;

namespace ManejoExtintores.Core.Modelos   
{
    public class Usuarios: IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Google { get; set; }
        public string Discriminador { get; set; } 

        public DateTime JoinDate { get; set; }
    }
}
