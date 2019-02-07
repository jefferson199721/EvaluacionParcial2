using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class Clientes
    {
        [Key]
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }

    }
}
