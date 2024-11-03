using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Truckoom_Assesment.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Truckoom_Assesment.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maintenance
        public ActionResult Index()
        {
            var maintenanceActivities = _context.MaintenanceActivities.Include("Vehicle").ToList();
            return View(maintenanceActivities);
        }
        // GET: Maintenance/Create
        public IActionResult Create()
        {
            ViewBag.VehicleID = new SelectList(_context.Vehicles, "VehicleID", "LicensePlate");
            return View();
        }

        // POST: Maintenance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleID,MaintenanceType,Date,Description,Notes")] MaintenanceActivity maintenanceActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenanceActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Log validation errors
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            ViewBag.VehicleID = new SelectList(_context.Vehicles, "VehicleID", "LicensePlate", maintenanceActivity.VehicleID);
            return View(maintenanceActivity);
        }





        // GET: Maintenance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceActivity = await _context.MaintenanceActivities
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.MaintenanceID == id);
            if (maintenanceActivity == null)
            {
                return NotFound();
            }

            return View(maintenanceActivity);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenanceActivity = await _context.MaintenanceActivities.FindAsync(id);
            _context.MaintenanceActivities.Remove(maintenanceActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
