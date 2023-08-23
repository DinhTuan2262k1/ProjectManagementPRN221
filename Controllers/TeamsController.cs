using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementPRN221.Extensions;
using ProjectManagementPRN221.Models;
using ProjectManagementPRN221.Repository;

namespace ProjectManagementPRN221.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ProjectManagementContext _context;
        private TeamRepo _teamRepo;

        public TeamsController(ProjectManagementContext context, TeamRepo teamRepo)
        {
            _context = context;
            _teamRepo = teamRepo;
        }

        // GET: Teams
        public async Task<IActionResult> Index()
        {
            var projectManagementContext = _context.Teams.Include(t => t.LeaderNavigation);
            return View(await projectManagementContext.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.LeaderNavigation)
                .Include(t => t.Mssvs)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            ViewData["Member"] = new SelectList(team.Mssvs, "Mssv", "StudentName");

            return View(team);
        }

        // GET: Teams/Create
        public IActionResult Create()
        {
            Student student = HttpContext.Session.Get<Student>("student");
            if (student != null)
            {
                ViewData["Leader"] = new SelectList(new List<Student> { student }, "Mssv", "StudentName");
            }
            ViewData["Leader"] = new SelectList(_context.Students, "Mssv", "StudentName");
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,TeamName,NumberOfMember,Leader")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Leader"] = new SelectList(_context.Students, "Mssv", "StudentName", team.Leader);
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.Include(t => t.LeaderNavigation)
                .Include(t => t.Mssvs).SingleOrDefaultAsync(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }
            Student student = HttpContext.Session.Get<Student>("student");
            if (student != null)
            {
                ViewData["Leader"] = new SelectList(new List<Student> { student }, "Mssv", "StudentName");
            }
            ViewData["Member"] = new SelectList(_context.Students, "Mssv", "StudentName", team.Leader);

            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,TeamName,NumberOfMember,Leader")] Team team, List<string> ids)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                    _teamRepo.InsertMemberTeam(ids, team.TeamId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            ViewData["Leader"] = new SelectList(_context.Students, "Mssv", "StudentName", team.Leader);
            ViewData["Member"] = new SelectList(_context.Students, "Mssv", "StudentName",team.Mssvs);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .Include(t => t.LeaderNavigation)
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Teams == null)
            {
                return Problem("Entity set 'ProjectManagementContext.Teams'  is null.");
            }
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
          return (_context.Teams?.Any(e => e.TeamId == id)).GetValueOrDefault();
        }
    }
}
