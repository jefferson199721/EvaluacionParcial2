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
    public class DistribuidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly DistribuidoresModel _distribuidor_model;

        public DistribuidoresController(ApplicationDbContext context)
        {
            _context = context;
            _distribuidor_model = new DistribuidoresModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Distribuidores.ToListAsync());
        }


        public IdentityError Nuevo_Distribuidor_Controller(string Nombres, string Direccion, string listaReseptor)
        {
            return _distribuidor_model.Nuevo_Distribuidor_Model(Nombres, Direccion, listaReseptor);

        }


        public Distribuidores Un_Distribuidor_Controller(int idDistribuidor)
        {
            return _distribuidor_model.Un_Distribuidor_Model(idDistribuidor);
        }
        public IdentityError Editar_Distribuidor_Controller(int idDistribuidor, string Nombres, string Direccion, string listaReseptor)
        {
            return _distribuidor_model.Editar_Distribuidor_Model(idDistribuidor, Nombres, Direccion, listaReseptor);

        }
        public IdentityError Eliminar_Distribuidor_Controller(int idDistribuidor)
        {
            return _distribuidor_model.Eliminar_Distribuidor_Model(idDistribuidor);
        }



        public List<object[]> Lista_Distribuidor_Controller()
        {
            return _distribuidor_model.Lista_Distribuidor_Model();
        }
    }
}
