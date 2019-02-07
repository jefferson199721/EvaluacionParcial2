using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvaParcial.Data;
using EvaParcial.Models;

namespace EvaParcial.Controllers
{
    public class RealizarPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealizarPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RealizarPedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RealizarPedido.Include(r => r.Cliente).Include(r => r.Pedidos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RealizarPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarPedido = await _context.RealizarPedido
                .Include(r => r.Cliente)
                .Include(r => r.Pedidos)
                .FirstOrDefaultAsync(m => m.idPedido == id);
            if (realizarPedido == null)
            {
                return NotFound();
            }

            return View(realizarPedido);
        }

        // GET: RealizarPedidos/Create
        public IActionResult Create()
        {
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "Nombre");
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "NomCorte");
            return View();
        }

        // POST: RealizarPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPedido,Fecha,idCliente,idPedidos")] RealizarPedido realizarPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realizarPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "idCliente", realizarPedido.idCliente);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "idPedidos", realizarPedido.idPedidos);
            return View(realizarPedido);
        }

        // GET: RealizarPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarPedido = await _context.RealizarPedido.FindAsync(id);
            if (realizarPedido == null)
            {
                return NotFound();
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "Nombre", realizarPedido.idCliente);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "NomCorte", realizarPedido.idPedidos);
            return View(realizarPedido);
        }

        // POST: RealizarPedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPedido,Fecha,idCliente,idPedidos")] RealizarPedido realizarPedido)
        {
            if (id != realizarPedido.idPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realizarPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealizarPedidoExists(realizarPedido.idPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "idCliente", realizarPedido.idCliente);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "idPedidos", realizarPedido.idPedidos);
            return View(realizarPedido);
        }

        // GET: RealizarPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizarPedido = await _context.RealizarPedido
                .Include(r => r.Cliente)
                .Include(r => r.Pedidos)
                .FirstOrDefaultAsync(m => m.idPedido == id);
            if (realizarPedido == null)
            {
                return NotFound();
            }

            return View(realizarPedido);
        }

        // POST: RealizarPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realizarPedido = await _context.RealizarPedido.FindAsync(id);
            _context.RealizarPedido.Remove(realizarPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealizarPedidoExists(int id)
        {
            return _context.RealizarPedido.Any(e => e.idPedido == id);
        }
    }
}
