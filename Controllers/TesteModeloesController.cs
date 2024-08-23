using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMVCApp.Data;
using RazorMVCApp.Models;

namespace RazorMVCApp.Controllers
{
    public class TesteModeloesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TesteModeloesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TesteModeloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TesteModelos.ToListAsync());
        }

        // GET: TesteModeloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testeModelo = await _context.TesteModelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testeModelo == null)
            {
                return NotFound();
            }

            return View(testeModelo);
        }

        // GET: TesteModeloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TesteModeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TesteModelo testeModelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testeModelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testeModelo);
        }

        // GET: TesteModeloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testeModelo = await _context.TesteModelos.FindAsync(id);
            if (testeModelo == null)
            {
                return NotFound();
            }
            return View(testeModelo);
        }

        // POST: TesteModeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TesteModelo testeModelo)
        {
            if (id != testeModelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testeModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesteModeloExists(testeModelo.Id))
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
            return View(testeModelo);
        }

        // GET: TesteModeloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testeModelo = await _context.TesteModelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testeModelo == null)
            {
                return NotFound();
            }

            return View(testeModelo);
        }

        // POST: TesteModeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testeModelo = await _context.TesteModelos.FindAsync(id);
            if (testeModelo != null)
            {
                _context.TesteModelos.Remove(testeModelo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesteModeloExists(int id)
        {
            return _context.TesteModelos.Any(e => e.Id == id);
        }
    }
}
