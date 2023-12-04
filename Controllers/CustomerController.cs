using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingCafe.Models;

namespace CodingCafe.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CafeContext _context;

        public CustomerController(CafeContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.StateSort = sortOrder == "State" ? "statedesc" : "state";

            var cust = from m in _context.Customers.Include(c => c.Favorites)
                       select m;
            if (_context.Customers == null)
            {
                return Problem("No Results");
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                cust = cust.Where(s => s.FirstName.Contains(searchString)
            || s.LastName.Contains(searchString)
            || s.Address.Contains(searchString)
            || s.State.Contains(searchString)
            || s.City.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    cust = cust.OrderByDescending(m => m.FirstName);
                    break;
                case "state":
                    cust = cust.OrderBy(m => m.State);
                    break;
                case "statedesc":
                    cust = cust.OrderByDescending(m => m.State);
                    break;
                default:
                    cust = cust.OrderBy(m => m.FirstName);
                    break;
            }

            return View(await cust.ToListAsync());
        }




        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Favorites)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            ViewData["Name"] = new SelectList(_context.Favorites, "FavoritesId", "Name");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,Phone,FavoritesId,Name")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Name"] = new SelectList(_context.Favorites, "FavoritesId", "Name", customers.FavoritesId);
            return View(customers);
        }

    

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Favorites)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customers == null)
            {
                return NotFound();
            }

            ViewData["Name"] = new SelectList(_context.Favorites, "FavoritesId", "Name", customers.FavoritesId);
            return View(customers);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address,City,State,Zip,Email,Phone,FavoritesId")] Customers customers)
        {
            if (id != customers.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing record with the correct FavoritesId
                    var existingCustomer = await _context.Customers.FindAsync(id);
                    if (existingCustomer == null)
                    {
                        return NotFound();
                    }

                    // Updated Properties
                    existingCustomer.FirstName = customers.FirstName;
                    existingCustomer.LastName = customers.LastName;
                    existingCustomer.Address = customers.Address;
                    existingCustomer.City = customers.City;
                    existingCustomer.State = customers.State;
                    existingCustomer.Zip = customers.Zip;
                    existingCustomer.Email = customers.Email;
                    existingCustomer.Phone = customers.Phone;

                    // Updated Favorites
                    existingCustomer.FavoritesId = customers.FavoritesId;

                    _context.Update(existingCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.ID))
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
            ViewData["Name"] = new SelectList(_context.Favorites, "FavoritesId", "Name", customers.FavoritesId);

            return View(customers);
        }


        //DELETE

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.Favorites)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'CafeContext.Customers'  is null.");
            }
            var customers = await _context.Customers.FindAsync(id);
            if (customers != null)
            {
                _context.Customers.Remove(customers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return (_context.Customers?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
