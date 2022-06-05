using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.domain.Entities;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using JagoRTT.domain.Entities.Enum;

namespace JagoRTT.UI.Controllers
{
    public class RentalController : BaseController<RentalVM>
    {
        private readonly ApplicationContext db;
        private readonly IRentalServices _rentalServices;
        private readonly ICompanyServices _ciaServices;
        private readonly IToolServices _toolServices;

        public RentalController(IRentalServices rentalServices,
            ICompanyServices ciaServices, IToolServices toolServices, ApplicationContext db) : base(db)
        {
            _rentalServices = rentalServices;
            _ciaServices = ciaServices;  
            _toolServices = toolServices;
        }

        // GET: Rental
        public async Task<IActionResult> Index()
        {
            return View(GetRows());
        }
        public override IEnumerable<RentalVM>GetRows()
        {
            return _rentalServices.GetRentedToolByDate();

        }
        public override RentalVM GetRow(Guid id)
        {
            return _rentalServices.GetById(id);
        }
        // GET: Rental/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || Db.Rentals == null)
            {
                return NotFound();
            }

            var rental = await Db.Rentals
                .Include(r => r.Company)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rental/Create
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Rental rental)
        {//rental.Id = Guid.NewGuid();
            LoadViewBags();
            if (ModelState.IsValid)
            {
                return View(rental);

            }
            Db.Rentals.Add(rental);
            Db.SaveChanges();
            //TempData["success"] = "Trip added successfully";
            return RedirectToAction("Index");
        }

        // GET: Rental/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            LoadViewBags();
            var item = Db.Rentals.FirstOrDefault(j => j.Id == id);
            if (item == null) return BadRequest();
            return View(item);
        }

        // POST: Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (Rental rental)
        {
            LoadViewBags();
            if (ModelState.IsValid)
            {
                return View(rental);

            }
            Db.Rentals.Update(rental);
            Db.SaveChanges();
           // TempData["success"] = "Trip updated successfully";
            return RedirectToAction("Index");
        }

        // GET: Rental/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || Db.Rentals == null)
            {
                return NotFound();
            }

            var rental = await Db.Rentals
                .Include(r => r.Company)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (Db.Rentals == null)
            {
                return Problem("Entity set 'ApplicationContext.Rentals'  is null.");
            }
            var rental = await Db.Rentals.FindAsync(id);
            if (rental != null)
            {
                Db.Rentals.Remove(rental);
            }
            
            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(Guid id)
        {
            return Db.Rentals.Any(e => e.Id == id);
        }
        public override void LoadViewBags()
        {
            LoadAsync();
        }
        public async void LoadAsync()
        {
            ViewBag.Companies = _rentalServices.GetCompanyList().ToList();
            ViewBag.Tools = _rentalServices.GetToolList().ToList();

            ViewBag.TypeOfRental = new List<SelectListItem>()
            {
                new SelectListItem("Monthly", Convert.ToString((int) ETypeOfRental.Monthly)),
                new SelectListItem("Per trimester", Convert.ToString((int) ETypeOfRental.Trimester)),
                new SelectListItem("Per semester", Convert.ToString((int) ETypeOfRental.Semester)),
                new SelectListItem("Weekly", Convert.ToString((int) ETypeOfRental.Weekly))

            };
        }
        
    }
}
