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
    public class EntregasController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly EntregaModel _entrega_model;

        public EntregasController(ApplicationDbContext context)
        {
            _context = context;
            _entrega_model = new EntregaModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrega.ToListAsync());
        }


        public IdentityError Nuevo_Entrega_Controller(DateTime Fecha, string ResponsableResive)
        {
            return _entrega_model.Nuevo_Entrega_Model(Fecha, ResponsableResive);

        }


        public Entrega Un_Entrega_Controller(int idEntrega)
        {
            return _entrega_model.Un_Entrega_Model(idEntrega);
        }
        public IdentityError Editar_Entrega_Controller(int idEntrega, DateTime Fecha, string ResponsableResive)
        {
            return _entrega_model.Editar_Entrega_Model(idEntrega, Fecha, ResponsableResive);

        }
        public IdentityError Eliminar_Entrega_Controller(int idEntrega)
        {
            return _entrega_model.Eliminar_Entrega_Model(idEntrega);
        }



        public List<object[]> Lista_Entrega_Controller()
        {
            return _entrega_model.Lista_Entrega_Model();
        }
    }
}
