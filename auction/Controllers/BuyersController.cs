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
    public class BuyersController : Controller
    {
        private readonly auctionContext _context;

        public BuyersController(auctionContext context)
        {
            _context = context;
        }

        // GET: Buyers
        public async Task<IActionResult> Index(string buyerFirst_name, string searchString)
        {
            if (_context.Buyer == null)
            {
                return Problem("Entity set 'auctionContext.Buyer'  is null.");
            }
            IQueryable<string> first_nameQuery = from f in _context.Buyer
                                            orderby f.first_name_buyer
                                            select f.first_name_buyer;
            var buyers = from b in _context.Buyer
                         select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                buyers = buyers.Where(s => s.last_name_buyer!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(buyerFirst_name))
            {
                buyers = buyers.Where(x => x.first_name_buyer == buyerFirst_name);
            }

            var buyerFirst_nameVM = new BuyerNameViewModel
            {
                First_names = new SelectList(await first_nameQuery.Distinct().ToListAsync()),
                Buyers = await buyers.ToListAsync()
            };
            return View(buyerFirst_nameVM);
        }


        // GET: Buyers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // GET: Buyers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,first_name_buyer,last_name_buyer,phone_number_buyer")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);
        }

        // GET: Buyers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer == null)
            {
                return NotFound();
            }
            return View(buyer);
        }

        // POST: Buyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,first_name_buyer,last_name_buyer,phone_number_buyer")] Buyer buyer)
        {
            if (id != buyer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyerExists(buyer.Id))
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
            return View(buyer);
        }

        // GET: Buyers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buyer == null)
            {
                return NotFound();
            }

            var buyer = await _context.Buyer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyer == null)
            {
                return NotFound();
            }

            return View(buyer);
        }

        // POST: Buyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buyer == null)
            {
                return Problem("Entity set 'auctionContext.Buyer'  is null.");
            }
            var buyer = await _context.Buyer.FindAsync(id);
            if (buyer != null)
            {
                _context.Buyer.Remove(buyer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyerExists(int id)
        {
          return (_context.Buyer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
