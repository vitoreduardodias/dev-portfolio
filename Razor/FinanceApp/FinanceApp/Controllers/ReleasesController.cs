using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Context;
using FinanceApp.Models.Tables;

namespace FinanceApp.Controllers
{
    public class ReleasesController : Controller
    {
        private readonly AppDbContext _context;

        public ReleasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Releases
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Releases.Include(r => r.Acc);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Releases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.Acc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // GET: Releases/Create
        public IActionResult Create()
        {
            ViewData["AccId"] = new SelectList(_context.Accounts, "Id", "Name");
            return View();
        }

        // POST: Releases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Description,Quantity,UnityValue,TotalValue,Direction,AccId")] Release release)
        {
            if (ModelState.IsValid)
            {
                _context.Add(release);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccId"] = new SelectList(_context.Accounts, "Id", "Name", release.AccId);
            return View(release);
        }

        // GET: Releases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases.FindAsync(id);
            if (release == null)
            {
                return NotFound();
            }
            ViewData["AccId"] = new SelectList(_context.Accounts, "Id", "Name", release.AccId);
            return View(release);
        }

        // POST: Releases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Description,Quantity,UnityValue,TotalValue,Direction,AccId")] Release release)
        {
            if (id != release.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(release);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReleaseExists(release.Id))
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
            ViewData["AccId"] = new SelectList(_context.Accounts, "Id", "Name", release.AccId);
            return View(release);
        }

        // GET: Releases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Releases == null)
            {
                return NotFound();
            }

            var release = await _context.Releases
                .Include(r => r.Acc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (release == null)
            {
                return NotFound();
            }

            return View(release);
        }

        // POST: Releases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Releases == null)
            {
                return Problem("Entity set 'AppDbContext.Releases'  is null.");
            }
            var release = await _context.Releases.FindAsync(id);
            if (release != null)
            {
                _context.Releases.Remove(release);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReleaseExists(int id)
        {
          return (_context.Releases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
