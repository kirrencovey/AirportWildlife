using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirportWildlife.Data;
using AirportWildlife.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AirportWildlife.Controllers
{
    public class AnimalActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnimalActivitiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: AnimalActivities
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.AnimalActivities.Include(a => a.User).Where(a => a.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AnimalActivities/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AnimalActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalActivityId,Name")] AnimalActivity animalActivity)
        {
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                animalActivity.User = user;
                animalActivity.UserId = user.Id;
                _context.Add(animalActivity);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalActivity);
        }

        // GET: AnimalActivities/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalActivity = await _context.AnimalActivities.FindAsync(id);
            if (animalActivity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", animalActivity.UserId);
            return View(animalActivity);
        }

        // POST: AnimalActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalActivityId,Name,UserId")] AnimalActivity animalActivity)
        {
            if (id != animalActivity.AnimalActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalActivityExists(animalActivity.AnimalActivityId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", animalActivity.UserId);
            return View(animalActivity);
        }

        // GET: AnimalActivities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalActivity = await _context.AnimalActivities
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AnimalActivityId == id);
            if (animalActivity == null)
            {
                return NotFound();
            }

            return View(animalActivity);
        }

        // POST: AnimalActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalActivity = await _context.AnimalActivities.FindAsync(id);
            _context.AnimalActivities.Remove(animalActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalActivityExists(int id)
        {
            return _context.AnimalActivities.Any(e => e.AnimalActivityId == id);
        }
    }
}
