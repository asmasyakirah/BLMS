using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLMS.Context;
using BLMS.Models;

namespace BLMS.Controllers
{
    public class CompetentPersonnelController : Controller
    {
        private readonly CompetentPersonnelDBContext _context;

        public CompetentPersonnelController(CompetentPersonnelDBContext context)
        {
            _context = context;
        }

        // GET: CompetentPersonnel
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompetentPersonnel.ToListAsync());
        }

        // GET: CompetentPersonnel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competentPersonnel = await _context.CompetentPersonnel
                .FirstOrDefaultAsync(m => m.PersonnelId == id);
            if (competentPersonnel == null)
            {
                return NotFound();
            }

            return View(competentPersonnel);
        }

        // GET: CompetentPersonnel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetentPersonnel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonnelId,PersonnelName,Icno,AppointedDt,CertFrom,CertType,CertNo,ExpiredDt,YearAwarded,CertFileName,RegNo,Branch,CreatedDt,CreatedBy,UpdatedDt,UpdatedBy,BusinessDiv,BusinessUnit")] CompetentPersonnel competentPersonnel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competentPersonnel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competentPersonnel);
        }

        // GET: CompetentPersonnel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competentPersonnel = await _context.CompetentPersonnel.FindAsync(id);
            if (competentPersonnel == null)
            {
                return NotFound();
            }
            return View(competentPersonnel);
        }

        // POST: CompetentPersonnel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonnelId,PersonnelName,Icno,AppointedDt,CertFrom,CertType,CertNo,ExpiredDt,YearAwarded,CertFileName,RegNo,Branch,CreatedDt,CreatedBy,UpdatedDt,UpdatedBy,BusinessDiv,BusinessUnit")] CompetentPersonnel competentPersonnel)
        {
            if (id != competentPersonnel.PersonnelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competentPersonnel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetentPersonnelExists(competentPersonnel.PersonnelId))
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
            return View(competentPersonnel);
        }

        // GET: CompetentPersonnel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competentPersonnel = await _context.CompetentPersonnel
                .FirstOrDefaultAsync(m => m.PersonnelId == id);
            if (competentPersonnel == null)
            {
                return NotFound();
            }

            return View(competentPersonnel);
        }

        // POST: CompetentPersonnel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competentPersonnel = await _context.CompetentPersonnel.FindAsync(id);
            _context.CompetentPersonnel.Remove(competentPersonnel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetentPersonnelExists(int id)
        {
            return _context.CompetentPersonnel.Any(e => e.PersonnelId == id);
        }
    }
}
