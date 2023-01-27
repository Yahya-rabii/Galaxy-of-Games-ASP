using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc_gog.Data;
using mvc_gog.Models;

namespace mvc_gog.Controllers
{
    public class LigneBackupsController : Controller
    {
        private readonly mvc_gogContext _context;

        public LigneBackupsController(mvc_gogContext context)
        {
            _context = context;
        }

        // GET: LigneBackups
        public async Task<IActionResult> Index()
        {
              return _context.LigneBackup != null ? 
                          View(await _context.LigneBackup.ToListAsync()) :
                          Problem("Entity set 'mvc_gogContext.LigneBackup'  is null.");
        }

        // GET: LigneBackups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LigneBackup == null)
            {
                return NotFound();
            }

            var ligneBackup = await _context.LigneBackup
                .FirstOrDefaultAsync(m => m.LigneBackupID == id);
            if (ligneBackup == null)
            {
                return NotFound();
            }

            return View(ligneBackup);
        }

        // GET: LigneBackups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LigneBackups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LigneBackupID,LignePanierID,PanierID,ProduitID,NbreArticle,Total,Prodname")] LigneBackup ligneBackup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ligneBackup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ligneBackup);
        }

        // GET: LigneBackups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LigneBackup == null)
            {
                return NotFound();
            }

            var ligneBackup = await _context.LigneBackup.FindAsync(id);
            if (ligneBackup == null)
            {
                return NotFound();
            }
            return View(ligneBackup);
        }

        // POST: LigneBackups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LigneBackupID,LignePanierID,PanierID,ProduitID,NbreArticle,Total,Prodname")] LigneBackup ligneBackup)
        {
            if (id != ligneBackup.LigneBackupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ligneBackup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LigneBackupExists(ligneBackup.LigneBackupID))
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
            return View(ligneBackup);
        }

        // GET: LigneBackups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LigneBackup == null)
            {
                return NotFound();
            }

            var ligneBackup = await _context.LigneBackup
                .FirstOrDefaultAsync(m => m.LigneBackupID == id);
            if (ligneBackup == null)
            {
                return NotFound();
            }

            return View(ligneBackup);
        }

        // POST: LigneBackups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LigneBackup == null)
            {
                return Problem("Entity set 'mvc_gogContext.LigneBackup'  is null.");
            }
            var ligneBackup = await _context.LigneBackup.FindAsync(id);
            if (ligneBackup != null)
            {
                _context.LigneBackup.Remove(ligneBackup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LigneBackupExists(int id)
        {
          return (_context.LigneBackup?.Any(e => e.LigneBackupID == id)).GetValueOrDefault();
        }
    }
}
