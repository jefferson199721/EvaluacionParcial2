using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class Pedidos
    {
        [Key]
        public int idPedidos { get; set; }
        public DateTime Fecha { get; set; }
        public string NomCorte { get; set; }
        public int NPiezas { get; set; }
        public decimal PesoCarne { get; set; }



    }
}
