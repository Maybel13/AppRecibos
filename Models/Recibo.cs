using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AppRecibos.Models
{
    public class Recibo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Especifique un proveedor.")]
        public string Proveedor { get; set; }

        [Required(ErrorMessage = "Especifique un monto.")]
        public float Monto { get; set; }

        [Required(ErrorMessage = "Especifique un tipo de moneda.")]
        public string Moneda { get; set; }

        [Required(ErrorMessage = "Especifique una fecha para el recibo.")]
        public DateTime Fecha { get; set; }

        //[Required(ErrorMessage = "Escriba un comentario.")]
        public string Comentario { get; set; }
    }
}
