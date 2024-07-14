using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_tasks_one.Data;

namespace MVC_tasks_one.Controllers
{
    public class FeedbacksController : Controller
    {
        private readonly MVC_tasks_oneContext _context;

        public FeedbacksController(MVC_tasks_oneContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            var mVC_tasks_oneContext = _context.Feedbacks.Include(f => f.Manager);
            return View(await mVC_tasks_oneContext.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .Include(f => f.Manager)
                .FirstOrDefaultAsync(m => m.FeedbackID == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["ManagerID"] = new SelectList(_context.Managers, "EmployeeId", "Discriminator");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackID,Title,ManagerID,Viewed,Message,Date")] Feedbacks feedbacks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbacks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManagerID"] = new SelectList(_context.Managers, "EmployeeId", "Discriminator", feedbacks.ManagerID);
            return View(feedbacks);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks == null)
            {
                return NotFound();
            }
            ViewData["ManagerID"] = new SelectList(_context.Managers, "EmployeeId", "Discriminator", feedbacks.ManagerID);
            return View(feedbacks);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackID,Title,ManagerID,Viewed,Message,Date")] Feedbacks feedbacks)
        {
            if (id != feedbacks.FeedbackID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbacks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbacksExists(feedbacks.FeedbackID))
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
            ViewData["ManagerID"] = new SelectList(_context.Managers, "EmployeeId", "Discriminator", feedbacks.ManagerID);
            return View(feedbacks);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.Feedbacks
                .Include(f => f.Manager)
                .FirstOrDefaultAsync(m => m.FeedbackID == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbacks = await _context.Feedbacks.FindAsync(id);
            if (feedbacks != null)
            {
                _context.Feedbacks.Remove(feedbacks);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbacksExists(int id)
        {
            return _context.Feedbacks.Any(e => e.FeedbackID == id);
        }
    }
}
