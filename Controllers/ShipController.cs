using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipCreator1.Data;
using ShipCreator1.Models;

namespace ShipCreator1.Controllers
{
    public class ShipController : Controller
    {
        private readonly ShipCreator1Context _context;

        public ShipController(ShipCreator1Context context)
        {
            _context = context;
        }

        // GET: Ship
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ships.ToListAsync());
        }

        // GET: Ship/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipID == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);
        }

        // GET: Ship/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ship/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipID,ShipName,ShipType,NauticalMilage,PledgedFaction")] Ship ship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ship);
        }

        // GET: Ship/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships.FindAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            return View(ship);
        }

        // POST: Ship/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipID,ShipName,ShipType,NauticalMilage,PledgedFaction")] Ship ship)
        {
            if (id != ship.ShipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipExists(ship.ShipID))
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
            return View(ship);
        }

        // GET: Ship/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ship = await _context.Ships
                .FirstOrDefaultAsync(m => m.ShipID == id);
            if (ship == null)
            {
                return NotFound();
            }

            return View(ship);  
        }

        // POST: Ship/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ship = await _context.Ships.FindAsync(id); 
            if (ship != null)
            {
                _context.Ships.Remove(ship); 
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipExists(int id)
        {
            return _context.Ships.Any(e => e.ShipID == id); 
        }
    }
}
