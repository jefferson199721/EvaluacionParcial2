using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaParcial.Data;
using EvaParcial.Models;
using Microsoft.AspNetCore.Identity;

namespace EvaParcial.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly PedidosModel _pedidos_model;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
            _pedidos_model = new PedidosModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pedidos.ToListAsync());
        }


        public IdentityError Nuevo_Pedido_Controller(DateTime Fecha, string NomCorte, int NPiezas, decimal PesoCarne)
        {
            return _pedidos_model.Nuevo_Pedido_Model(Fecha, NomCorte, NPiezas, PesoCarne);

        }


        public Pedidos Un_Pedidos_Controller(int idPedidos)
        {
            
            return _pedidos_model.Un_Pedidos_Model(idPedidos);
        }
        public IdentityError Editar_Pedidos_Controller(int idPedidos, DateTime Fecha, string NomCorte, int NPiezas, decimal PesoCarne)
        {
            return _pedidos_model.Editar_Pedidos_Model(idPedidos, Fecha, NomCorte, NPiezas, PesoCarne);

        }
        public IdentityError Eliminar_Pedidos_Controller(int idPedidos)
        {
            return _pedidos_model.Eliminar_Pedidos_Model(idPedidos);
        }



        public List<object[]> Lista_Pedidos_Controller()
        {
            return _pedidos_model.Lista_Pedidos_Model();
        }
    }
}
