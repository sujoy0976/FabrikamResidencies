using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FabrikamResidences_Activities.Data;
using FabrikamResidences_Activities.Models;

namespace FabrikamResidences_Activities.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ActivityContext _context;

        public ActivitiesController(ActivityContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            await SeedActivities();
            return View(await _context.Activity.ToListAsync());
        }

        // See ActivityContext for details on why Seed data is being addressed here.
        private async Task SeedActivities()
        {
            if (!_context.Activity.Any())
            {

                var now = DateTime.Now;

                _context.Add(
                    new ActivityModel()
                    {
                        Name = "Bingo",
                        Description = "Come join us for an exciting game of Bingo with great prizes.",
                        Date = new DateTime(now.Year, now.Month, now.AddDays(2).Day, 12, 00, 00)
                    }
                );

                _context.Add(
                    new ActivityModel()
                    {
                        Name = "Shuffleboard Competition",
                        Description = "Meet us at the Shuffleboard court!",
                        Date = new DateTime(now.Year, now.Month, now.AddDays(5).Day, 18, 00, 00)
                    }
                );

                await _context.SaveChangesAsync();
            }
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string modifyDate, [Bind("Name,Description,Date")] ActivityModel activityModel)
        {
            activityModel.Date = Convert.ToDateTime(modifyDate);

            if (ModelState.IsValid)
            {
                if (ValidateActivityTime(activityModel.Date))
                {
                    _context.Add(activityModel);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(activityModel);
        }

        private bool ValidateActivityTime(DateTime date)
        {
            return date.Hour > 8 && date.Hour < 18;
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.Activity.FindAsync(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            return View(activityModel);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date")] ActivityModel activityModel)
        {
            if (id != activityModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityModelExists(activityModel.Id))
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
            return View(activityModel);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityModel = await _context.Activity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activityModel == null)
            {
                return NotFound();
            }

            return View(activityModel);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityModel = await _context.Activity.FindAsync(id);
            _context.Activity.Remove(activityModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityModelExists(int id)
        {
            return _context.Activity.Any(e => e.Id == id);
        }
    }
}
