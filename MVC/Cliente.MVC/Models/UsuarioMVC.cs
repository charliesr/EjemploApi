using Cliente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.MVC.Models
{
    public class UsuarioMVC
    {
        public UsuarioMVC(UsuarioServiceModel usuarioFromService)
        {
            this.Id = usuarioFromService.Id;
            this.Nombre = usuarioFromService.Nombre;
            this.Apellidos = usuarioFromService.Apellidos;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}