using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportWildlife.Data;
using AirportWildlife.Models;

namespace AirportWildlife.Controllers
{
    public class InteractionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InteractionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Interactions.Include(i => i.AnimalActivity).Include(i => i.ControlMethod).Include(i => i.Employee).Include(i => i.Habitat).Include(i => i.Species).Include(i => i.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interactions
                .Include(i => i.AnimalActivity)
                .Include(i => i.ControlMethod)
                .Include(i => i.Employee)
                .Include(i => i.Habitat)
                .Include(i => i.Species)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.InteractionId == id);
            if (interaction == null)
            {
                return NotFound();
            }

            return View(interaction);
        }

        // GET: Interactions/Create
        public IActionResult Create()
        {
            ViewData["AnimalActivityId"] = new SelectList(_context.AnimalActivities, "AnimalActivityId", "Name");
            ViewData["ControlMethodId"] = new SelectList(_context.ControlMethods, "ControlMethodId", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Initials");
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "HabitatId", "Name");
            ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Interactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InteractionId,Location,SpeciesCount,NumberTaken,DateTime,Comments,SpeciesId,AnimalActivityId,HabitatId,ControlMethodId,EmployeeId,UserId")] Interaction interaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalActivityId"] = new SelectList(_context.AnimalActivities, "AnimalActivityId", "Name", interaction.AnimalActivityId);
            ViewData["ControlMethodId"] = new SelectList(_context.ControlMethods, "ControlMethodId", "Name", interaction.ControlMethodId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Initials", interaction.EmployeeId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "HabitatId", "Name", interaction.HabitatId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "Name", interaction.SpeciesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", interaction.UserId);
            return View(interaction);
        }

        // GET: Interactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interactions.FindAsync(id);
            if (interaction == null)
            {
                return NotFound();
            }
            ViewData["AnimalActivityId"] = new SelectList(_context.AnimalActivities, "AnimalActivityId", "Name", interaction.AnimalActivityId);
            ViewData["ControlMethodId"] = new SelectList(_context.ControlMethods, "ControlMethodId", "Name", interaction.ControlMethodId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Initials", interaction.EmployeeId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "HabitatId", "Name", interaction.HabitatId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "Name", interaction.SpeciesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", interaction.UserId);
            return View(interaction);
        }

        // POST: Interactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InteractionId,Location,SpeciesCount,NumberTaken,DateTime,Comments,SpeciesId,AnimalActivityId,HabitatId,ControlMethodId,EmployeeId,UserId")] Interaction interaction)
        {
            if (id != interaction.InteractionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InteractionExists(interaction.InteractionId))
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
            ViewData["AnimalActivityId"] = new SelectList(_context.AnimalActivities, "AnimalActivityId", "Name", interaction.AnimalActivityId);
            ViewData["ControlMethodId"] = new SelectList(_context.ControlMethods, "ControlMethodId", "Name", interaction.ControlMethodId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Initials", interaction.EmployeeId);
            ViewData["HabitatId"] = new SelectList(_context.Habitats, "HabitatId", "Name", interaction.HabitatId);
            ViewData["SpeciesId"] = new SelectList(_context.Species, "SpeciesId", "Name", interaction.SpeciesId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", interaction.UserId);
            return View(interaction);
        }

        // GET: Interactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interaction = await _context.Interactions
                .Include(i => i.AnimalActivity)
                .Include(i => i.ControlMethod)
                .Include(i => i.Employee)
                .Include(i => i.Habitat)
                .Include(i => i.Species)
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.InteractionId == id);
            if (interaction == null)
            {
                return NotFound();
            }

            return View(interaction);
        }

        // POST: Interactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interaction = await _context.Interactions.FindAsync(id);
            _context.Interactions.Remove(interaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InteractionExists(int id)
        {
            return _context.Interactions.Any(e => e.InteractionId == id);
        }
    }
}
