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
    public class DetallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detalle.Include(d => d.Clientes).Include(d => d.Distribuidores);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Detalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle
                .Include(d => d.Clientes)
                .Include(d => d.Distribuidores)
                .FirstOrDefaultAsync(m => m.idDetalle == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // GET: Detalles/Create
        public IActionResult Create()
        {
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "Nombre");
            ViewData["idDistribuidor"] = new SelectList(_context.Distribuidores, "idDistribuidor", "Nombres");
            return View();
        }

        // POST: Detalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDetalle,idCliente,idDistribuidor")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "idCliente", detalle.idCliente);
            ViewData["idDistribuidor"] = new SelectList(_context.Distribuidores, "idDistribuidor", "idDistribuidor", detalle.idDistribuidor);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "Nombre", detalle.idCliente);
            ViewData["idDistribuidor"] = new SelectList(_context.Distribuidores, "idDistribuidor", "Nombres", detalle.idDistribuidor);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDetalle,idCliente,idDistribuidor")] Detalle detalle)
        {
            if (id != detalle.idDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleExists(detalle.idDetalle))
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
            ViewData["idCliente"] = new SelectList(_context.Cliente, "idCliente", "idCliente", detalle.idCliente);
            ViewData["idDistribuidor"] = new SelectList(_context.Distribuidores, "idDistribuidor", "idDistribuidor", detalle.idDistribuidor);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle = await _context.Detalle
                .Include(d => d.Clientes)
                .Include(d => d.Distribuidores)
                .FirstOrDefaultAsync(m => m.idDetalle == id);
            if (detalle == null)
            {
                return NotFound();
            }

            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle = await _context.Detalle.FindAsync(id);
            _context.Detalle.Remove(detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleExists(int id)
        {
            return _context.Detalle.Any(e => e.idDetalle == id);
        }
    }
}
