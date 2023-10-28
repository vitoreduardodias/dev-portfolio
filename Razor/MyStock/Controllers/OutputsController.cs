using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyStock.Data;
using MyStock.Models.Tables;

namespace MyStock.Controllers
{
    public class OutputsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OutputsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Outputs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Outputs.Include(o => o.ProductOut);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult CustomError()
        {
            // Página personalizada de erro para o cliente
            return View();
        }

        // GET: Outputs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.ProductOut)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // GET: Outputs/Create
        public IActionResult Create()
        {
            ViewData["ProductOutId"] = new SelectList(_context.Products, "Id", "Title");
            return View();
        }

        // POST: Outputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductOutId,Quantity,OutDate,Recipient")] Output output)
        {
            if (ModelState.IsValid)
            {
                _context.Add(output);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductOutId"] = new SelectList(_context.Products, "Id", "Title", output.ProductOutId);
            return View(output);
        }

        // GET: Outputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs.FindAsync(id);
            if (output == null)
            {
                return NotFound();
            }
            ViewData["ProductOutId"] = new SelectList(_context.Products, "Id", "Title", output.ProductOutId);
            return View(output);
        }

        // POST: Outputs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductOutId,Quantity,OutDate,Recipient")] Output output)
        {
            if (id != output.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(output);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutputExists(output.Id))
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
            ViewData["ProductOutId"] = new SelectList(_context.Products, "Id", "Title", output.ProductOutId);
            return View(output);
        }

        // GET: Outputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Outputs == null)
            {
                return NotFound();
            }

            var output = await _context.Outputs
                .Include(o => o.ProductOut)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (output == null)
            {
                return NotFound();
            }

            return View(output);
        }

        // POST: Outputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Outputs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Outputs'  is null.");
            }
            var output = await _context.Outputs.FindAsync(id);
            if (output != null)
            {
                _context.Outputs.Remove(output);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OutputExists(int id)
        {
            return (_context.Outputs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
