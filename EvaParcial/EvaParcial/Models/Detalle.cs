using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class Detalle
    {
        [Key]
        public int idDetalle { get; set; }

        public Clientes Clientes { get; set; }
        public int idCliente { get; set; }

        public Distribuidores Distribuidores { get; set; }
        public int idDistribuidor { get; set; }

    }
}
