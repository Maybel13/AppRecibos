using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AppRecibos.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Teclee el usuario.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Teclee la contraseña.")]
        public string Contrasena { get; set; }
    }
}
