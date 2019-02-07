using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class Entrega
    {
        [Key]
        public int idEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public string ResponsableResive { get; set; }

    }
}
