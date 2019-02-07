using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaParcial.Models
{
    public class RealizarPedido
    {
        [Key]
        public int idPedido { get; set; }
        public DateTime Fecha { get; set; }

        public Clientes Cliente { get; set; }
        public int idCliente { get; set; }

        public Pedidos Pedidos { get; set; }
        public int idPedidos { get; set; }
    }
}
