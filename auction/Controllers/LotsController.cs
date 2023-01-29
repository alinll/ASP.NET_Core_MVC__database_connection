using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using auction.Data;
using auction.Models;

namespace auction.Controllers
{
    public class LotsController : Controller
    {
        private readonly auctionContext _context;

        public LotsController(auctionContext context)
        {
            _context = context;
        }

        // GET: Lots
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Lot == null)
            {
                return Problem("Entity set 'auctionContext.Lot'  is null.");
            }
            var lots = from l in _context.Lot
                       select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                lots = lots.Where(s => s.name_order!.Contains(searchString));
            }
            return View(await lots.ToListAsync());
        }

        // GET: Lots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // GET: Lots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name_order,starting_price,buyer_id_buyer,seller_id_seller")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lot);
        }

        // GET: Lots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot.FindAsync(id);
            if (lot == null)
            {
                return NotFound();
            }
            return View(lot);
        }

        // POST: Lots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name_order,starting_price,buyer_id_buyer,seller_id_seller")] Lot lot)
        {
            if (id != lot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotExists(lot.Id))
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
            return View(lot);
        }

        // GET: Lots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lot == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // POST: Lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lot == null)
            {
                return Problem("Entity set 'auctionContext.Lot'  is null.");
            }
            var lot = await _context.Lot.FindAsync(id);
            if (lot != null)
            {
                _context.Lot.Remove(lot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LotExists(int id)
        {
          return (_context.Lot?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
