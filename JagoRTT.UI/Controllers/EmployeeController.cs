using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.domain.Entities;
using JagoRTT.Application.Interfaces.Services;
using JagoRTT.Application.ViewModel;

namespace JagoRTT.UI.Controllers
{
    public class EmployeeController : BaseController<EmployeeVM>
    {
        private readonly ApplicationContext db;
        private readonly IEmployeeServices _employeeServices;
        private readonly ICompanyServices _ciaServices;
        private readonly IToolServices _toolServices;
        private readonly IRentalServices _rentalServices;

        public EmployeeController(IEmployeeServices employeeServices,
            ICompanyServices ciaServices, IToolServices toolServices, IRentalServices rentalServices, ApplicationContext db) : base(db)
        {
            _employeeServices = employeeServices;
            _ciaServices = ciaServices;
            _toolServices = toolServices;

        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(GetRows());
        }
        public override IEnumerable<EmployeeVM> GetRows()
        {
            return _employeeServices.GetAll();

        }
        public override EmployeeVM GetRow(Guid id)
        {
            return _employeeServices.GetById(id);
        }
        // GET: Employee/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || Db.Employees == null)
            {
                return NotFound();
            }

            var employee = await Db.Employees
                .Include(r => r.Company)
                .Include(r => r.Tool)
                .Include(_=>_.Rental)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {//employee.Id = Guid.NewGuid();
            LoadViewBags();
            if (ModelState.IsValid)
            {
                return View(employee);

            }
            Db.Employees.Add(employee);
            Db.SaveChanges();
            //TempData["success"] = "Trip added successfully";
            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            LoadViewBags();
            var item = Db.Employees.FirstOrDefault(j => j.Id == id);
            if (item == null) return BadRequest();
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            LoadViewBags();
            if (ModelState.IsValid)
            {
                return View(employee);

            }
            Db.Employees.Update(employee);
            Db.SaveChanges();
            // TempData["success"] = "Trip updated successfully";
            return RedirectToAction("Index");
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || Db.Employees == null)
            {
                return NotFound();
            }

            var employee = await Db.Employees
                .Include(r => r.Company)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (Db.Employees == null)
            {
                return Problem("Entity set 'ApplicationContext.Employees'  is null.");
            }
            var employee = await Db.Employees.FindAsync(id);
            if (employee != null)
            {
                Db.Employees.Remove(employee);
            }

            await Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(Guid id)
        {
            return Db.Employees.Any(e => e.Id == id);
        }
        public override void LoadViewBags()
        {
            LoadAsync();
        }
        public async void LoadAsync()
        {
            ViewBag.Companies = _employeeServices.GetCompanyList().ToList();
            ViewBag.Tools = _employeeServices.GetToolList().ToList();
            ViewBag.Rentals = _employeeServices.GetRentalList().ToList();

        }

    }
}
