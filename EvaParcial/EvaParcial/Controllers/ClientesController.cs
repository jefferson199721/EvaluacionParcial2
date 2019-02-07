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
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ClientesModel _clientes_model;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
            _clientes_model = new ClientesModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }


        public IdentityError Nuevo_Cliente_Controller(string Nombre, string Direccion, string Ruc)
        {
            return _clientes_model.Nuevo_Cliente_Model(Nombre, Direccion, Ruc);

        }


        public Clientes Un_Cliente_Controller(int idCliente)
        {
            return _clientes_model.Un_Cliente_Model(idCliente);
        }
        public IdentityError Editar_Cliente_Controller(int idCliente, string Nombre, string Direccion, string Ruc)
        {
            return _clientes_model.Editar_Cliente_Model(idCliente, Nombre, Direccion, Ruc);

        }
        public IdentityError Eliminar_Cliente_Controller(int idCliente)
        {
            return _clientes_model.Eliminar_Cliente_Model(idCliente);
        }



        public List<object[]> Lista_Clientes_Controller()
        {
            return _clientes_model.Lista_Clientes_Model();
        }
    }
}
