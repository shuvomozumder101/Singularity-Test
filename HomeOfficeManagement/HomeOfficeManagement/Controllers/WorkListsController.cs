using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeOfficeManagement.Data;
using HomeOfficeManagement.Entity;

namespace HomeOfficeManagement.Controllers
{
    public class WorkListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkList.ToListAsync());
        }

        // GET: WorkLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workList = await _context.WorkList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workList == null)
            {
                return NotFound();
            }

            return View(workList);
        }

        // GET: WorkLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Date,WorkDetails")] WorkList workList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workList);
        }

        // GET: WorkLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workList = await _context.WorkList.FindAsync(id);
            if (workList == null)
            {
                return NotFound();
            }
            return View(workList);
        }

        // POST: WorkLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Date,WorkDetails")] WorkList workList)
        {
            if (id != workList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkListExists(workList.Id))
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
            return View(workList);
        }

        // GET: WorkLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workList = await _context.WorkList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workList == null)
            {
                return NotFound();
            }

            return View(workList);
        }

        // POST: WorkLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workList = await _context.WorkList.FindAsync(id);
            _context.WorkList.Remove(workList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkListExists(int id)
        {
            return _context.WorkList.Any(e => e.Id == id);
        }
    }
}
