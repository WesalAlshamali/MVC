using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_tasks_one.Data;
using MVC_tasks_one.Models;

namespace MVC_tasks_one.Controllers
{
    public class ManagersController : Controller
    {
        private readonly MVC_tasks_oneContext _context;

        public ManagersController(MVC_tasks_oneContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
            var mVC_tasks_oneContext = _context.Managers.Include(m => m.Department);
            return View(await mVC_tasks_oneContext.ToListAsync());
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .Include(m => m.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,PhoneNumber,JobTitle,Salary,Address,DepartmentId")] Managers managers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", managers.DepartmentId);
            return View(managers);
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers.FindAsync(id);
            if (managers == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", managers.DepartmentId);
            return View(managers);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,PhoneNumber,JobTitle,Salary,Address,DepartmentId")] Managers managers)
        {
            if (id != managers.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagersExists(managers.EmployeeId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", managers.DepartmentId);
            return View(managers);
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managers = await _context.Managers
                .Include(m => m.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (managers == null)
            {
                return NotFound();
            }

            return View(managers);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var managers = await _context.Managers.FindAsync(id);
            if (managers != null)
            {
                _context.Managers.Remove(managers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagersExists(int id)
        {
            return _context.Managers.Any(e => e.EmployeeId == id);
        }
    }
}
