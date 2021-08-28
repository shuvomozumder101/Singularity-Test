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
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attendees.ToListAsync());
        }

        // GET: Attendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendees = await _context.Attendees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendees == null)
            {
                return NotFound();
            }

            return View(attendees);
        }

        // GET: Attendees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Date,Attend,DueTime")] Attendees attendees)
        {
            if (ModelState.IsValid)
            {
                attendees.Attend = true;
                attendees.Date = DateTime.Now;
                attendees.DueTime = new DateTime(attendees.Date.Year, attendees.Date.Month, attendees.Date.Day, 10, 0, 0);
                _context.Add(attendees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attendees);
        }

    }
}
