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
    public class CustomUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CustomUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomUsers.ToListAsync());
        }

        // GET: CustomUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customUsers = await _context.CustomUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customUsers == null)
            {
                return NotFound();
            }

            return View(customUsers);
        }

        // GET: CustomUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,RoleName,RoleId")] CustomUsers customUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customUsers);
        }

        // GET: CustomUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customUsers = await _context.CustomUsers.FindAsync(id);
            if (customUsers == null)
            {
                return NotFound();
            }
            return View(customUsers);
        }

        // POST: CustomUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,RoleName,RoleId")] CustomUsers customUsers)
        {
            if (id != customUsers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomUsersExists(customUsers.Id))
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
            return View(customUsers);
        }

        // GET: CustomUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customUsers = await _context.CustomUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customUsers == null)
            {
                return NotFound();
            }

            return View(customUsers);
        }

        // POST: CustomUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customUsers = await _context.CustomUsers.FindAsync(id);
            if (customUsers != null)
            {
                _context.CustomUsers.Remove(customUsers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomUsersExists(int id)
        {
            return _context.CustomUsers.Any(e => e.Id == id);
        }
    }
}
