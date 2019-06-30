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
    public class ControlMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ControlMethodsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: ControlMethods
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.ControlMethods.Include(c => c.User).Where(a => a.UserId == user.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ControlMethods/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ControlMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ControlMethodId,Name")] ControlMethod controlMethod)
        {
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                controlMethod.User = user;
                controlMethod.UserId = user.Id;
                _context.Add(controlMethod);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controlMethod);
        }

        // GET: ControlMethods/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlMethod = await _context.ControlMethods.FindAsync(id);
            if (controlMethod == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", controlMethod.UserId);
            return View(controlMethod);
        }

        // POST: ControlMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ControlMethodId,Name,UserId")] ControlMethod controlMethod)
        {
            if (id != controlMethod.ControlMethodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlMethodExists(controlMethod.ControlMethodId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", controlMethod.UserId);
            return View(controlMethod);
        }

        // GET: ControlMethods/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlMethod = await _context.ControlMethods
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.ControlMethodId == id);
            if (controlMethod == null)
            {
                return NotFound();
            }

            return View(controlMethod);
        }

        // POST: ControlMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlMethod = await _context.ControlMethods.FindAsync(id);
            _context.ControlMethods.Remove(controlMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlMethodExists(int id)
        {
            return _context.ControlMethods.Any(e => e.ControlMethodId == id);
        }
    }
}
