using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoShopping;
using DemoShopping.Models;

namespace DemoShopping.Controllers
{
    public class ListsController : Controller
    {
        private readonly DemoShoppingDbContext _context;

        public ListsController(DemoShoppingDbContext context)
        {
            _context = context;
        }

        // GET: Lists
        public async Task<IActionResult> Index()
        {
              return View(await _context.ShoppingLists.ToListAsync());
        }

        // GET: Lists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingLists == null)
            {
                return NotFound();
            }

            var list = await _context.ShoppingLists
                .FirstOrDefaultAsync(m => m.ListID == id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        // GET: Lists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListID,Title,isEnable")] List list)
        {
            var nameCookie = Request.Cookies["Name"].Value;
            if (ModelState.IsValid)
            {
                _context.Add(list);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(list);
        }

        // GET: Lists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingLists == null)
            {
                return NotFound();
            }

            var list = await _context.ShoppingLists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }

        // POST: Lists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListID,Title,isEnable")] List list)
        {
            if (id != list.ListID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(list);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListExists(list.ListID))
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
            return View(list);
        }

        // GET: Lists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingLists == null)
            {
                return NotFound();
            }

            var list = await _context.ShoppingLists
                .FirstOrDefaultAsync(m => m.ListID == id);
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingLists == null)
            {
                return Problem("Entity set 'DemoShoppingDbContext.ShoppingLists'  is null.");
            }
            var list = await _context.ShoppingLists.FindAsync(id);
            if (list != null)
            {
                _context.ShoppingLists.Remove(list);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListExists(int id)
        {
          return _context.ShoppingLists.Any(e => e.ListID == id);
        }
    }
}
