using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class EstableserEntrega
    {
        [Key]
        public int idEsEntrega { get; set; }

        public Entrega Entrega { get; set; }
        public int idEntrega { get; set; }
        public Pedidos Pedidos { get; set; }
        public int idPedidos { get; set; }
    }
}
