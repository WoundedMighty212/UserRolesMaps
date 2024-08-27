using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserRolesMaps.Data;
using UserRolesMaps.Models;

namespace UserRolesMaps.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomRoles.ToListAsync());
        }

        // GET: CustomRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customRoles = await _context.CustomRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customRoles == null)
            {
                return NotFound();
            }

            return View(customRoles);
        }

        // GET: CustomRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName")] CustomRoles customRoles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customRoles);
        }

        // GET: CustomRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customRoles = await _context.CustomRoles.FindAsync(id);
            if (customRoles == null)
            {
                return NotFound();
            }
            return View(customRoles);
        }

        // POST: CustomRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName")] CustomRoles customRoles)
        {
            if (id != customRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomRolesExists(customRoles.Id))
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
            return View(customRoles);
        }

        // GET: CustomRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customRoles = await _context.CustomRoles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customRoles == null)
            {
                return NotFound();
            }

            return View(customRoles);
        }

        // POST: CustomRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customRoles = await _context.CustomRoles.FindAsync(id);
            if (customRoles != null)
            {
                _context.CustomRoles.Remove(customRoles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomRolesExists(int id)
        {
            return _context.CustomRoles.Any(e => e.Id == id);
        }
    }
}
