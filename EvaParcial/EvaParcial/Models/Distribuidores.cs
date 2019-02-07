using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class Distribuidores
    {
        [Key]
        public int idDistribuidor { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string listaReseptor { get; set; }
    }
}
