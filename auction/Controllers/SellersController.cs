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
    public class SellersController : Controller
    {
        private readonly auctionContext _context;

        public SellersController(auctionContext context)
        {
            _context = context;
        }

        // GET: Sellers
        public async Task<IActionResult> Index(string sellerFirst_name, string searchString)
        {
            if (_context.Seller == null)
            {
                return Problem("Entity set 'auctionContext.Seller'  is null.");
            }
            IQueryable<string> first_nameQuery = from f in _context.Seller
                                                 orderby f.first_name_seller
                                                 select f.first_name_seller;
            var sellers = from ss in _context.Seller
                         select ss;
            if (!String.IsNullOrEmpty(searchString))
            {
                sellers = sellers.Where(s => s.last_name_seller!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(sellerFirst_name))
            {
                sellers = sellers.Where(x => x.first_name_seller == sellerFirst_name);
            }

            var sellerFirst_nameVM = new SellerNameViewModel
            {
                First_names = new SelectList(await first_nameQuery.Distinct().ToListAsync()),
                Sellers = await sellers.ToListAsync()
            };
            return View(sellerFirst_nameVM);
        }


        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seller == null)
            {
                return NotFound();
            }

            var seller = await _context.Seller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,first_name_seller,last_name_seller,phone_number_seller")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seller == null)
            {
                return NotFound();
            }

            var seller = await _context.Seller.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,first_name_seller,last_name_seller,phone_number_seller")] Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.Id))
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
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seller == null)
            {
                return NotFound();
            }

            var seller = await _context.Seller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seller == null)
            {
                return Problem("Entity set 'auctionContext.Seller'  is null.");
            }
            var seller = await _context.Seller.FindAsync(id);
            if (seller != null)
            {
                _context.Seller.Remove(seller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
          return (_context.Seller?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
