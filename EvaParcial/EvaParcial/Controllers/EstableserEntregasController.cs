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
    public class EstableserEntregasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstableserEntregasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstableserEntregas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EstableserEntrega.Include(e => e.Entrega).Include(e => e.Pedidos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EstableserEntregas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estableserEntrega = await _context.EstableserEntrega
                .Include(e => e.Entrega)
                .Include(e => e.Pedidos)
                .FirstOrDefaultAsync(m => m.idEsEntrega == id);
            if (estableserEntrega == null)
            {
                return NotFound();
            }

            return View(estableserEntrega);
        }

        // GET: EstableserEntregas/Create
        public IActionResult Create()
        {
            ViewData["idEntrega"] = new SelectList(_context.Entrega, "idEntrega", "Fecha");
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "NomCorte");
            return View();
        }

        // POST: EstableserEntregas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEsEntrega,idEntrega,idPedidos")] EstableserEntrega estableserEntrega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estableserEntrega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idEntrega"] = new SelectList(_context.Entrega, "idEntrega", "idEntrega", estableserEntrega.idEntrega);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "idPedidos", estableserEntrega.idPedidos);
            return View(estableserEntrega);
        }

        // GET: EstableserEntregas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estableserEntrega = await _context.EstableserEntrega.FindAsync(id);
            if (estableserEntrega == null)
            {
                return NotFound();
            }
            ViewData["idEntrega"] = new SelectList(_context.Entrega, "idEntrega", "Fecha", estableserEntrega.idEntrega);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "NomCorte", estableserEntrega.idPedidos);
            return View(estableserEntrega);
        }

        // POST: EstableserEntregas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEsEntrega,idEntrega,idPedidos")] EstableserEntrega estableserEntrega)
        {
            if (id != estableserEntrega.idEsEntrega)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estableserEntrega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstableserEntregaExists(estableserEntrega.idEsEntrega))
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
            ViewData["idEntrega"] = new SelectList(_context.Entrega, "idEntrega", "idEntrega", estableserEntrega.idEntrega);
            ViewData["idPedidos"] = new SelectList(_context.Pedidos, "idPedidos", "idPedidos", estableserEntrega.idPedidos);
            return View(estableserEntrega);
        }

        // GET: EstableserEntregas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estableserEntrega = await _context.EstableserEntrega
                .Include(e => e.Entrega)
                .Include(e => e.Pedidos)
                .FirstOrDefaultAsync(m => m.idEsEntrega == id);
            if (estableserEntrega == null)
            {
                return NotFound();
            }

            return View(estableserEntrega);
        }

        // POST: EstableserEntregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estableserEntrega = await _context.EstableserEntrega.FindAsync(id);
            _context.EstableserEntrega.Remove(estableserEntrega);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstableserEntregaExists(int id)
        {
            return _context.EstableserEntrega.Any(e => e.idEsEntrega == id);
        }
    }
}
