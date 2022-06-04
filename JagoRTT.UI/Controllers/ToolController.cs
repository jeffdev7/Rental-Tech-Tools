using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JagoRTT.Infrastructure.DBConfiguration;
using JagoRTT.domain.Entities;
using JagoRTT.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using JagoRTT.domain.Entities.Enum;
using JagoRTT.Application.ViewModel;

namespace JagoRTT.UI.Controllers
{
    public class ToolController : BaseController<ToolVM>
    {
        private readonly ApplicationContext _context;
        private readonly IToolServices _toolServices;

        public ToolController(IToolServices toolServices, ApplicationContext db) : base(db)
        {
            _toolServices = toolServices;
        }

        public override IEnumerable<ToolVM>GetRows()
        {
            return _toolServices.GetAll();
        }
        public override ToolVM GetRow(Guid id)
        {
           return _toolServices.GetById(id);
        }
        // GET: Tool
        [HttpGet]
        public IActionResult Index()
        {
              return View(GetRows());
        }

        // GET: Tool/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || Db.Tools == null)
            {
                return NotFound();
            }

            var tool = await Db.Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tool/Create
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tool tool)
        {
            LoadViewBags();
            if (ModelState.IsValid)
            {
                tool.Id = Guid.NewGuid();
                Db.Tools.Add(tool);
                Db.SaveChanges();
                return RedirectToAction("Index");

            }
           
            //TempData["success"] = "Trip added successfully";
                return View(tool);

        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            LoadViewBags();
            var item = Db.Tools.FirstOrDefault(j => j.Id == id);
            if (item == null) return BadRequest();
            return View(item);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tool tool)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
                return View(tool);

            var item = Db.Tools.AsNoTracking().Where(_ => _.Id == tool.Id);
            if (item == null) return BadRequest();
            Db.Entry(tool).State = EntityState.Modified;
            Db.SaveChanges();
            //TempData["success"] = "Passenger updated successfully";
            return RedirectToAction("Index");
        }
       
        // GET: Tool/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await Db.Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
            
        }

        // POST: Tool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tool = await Db.Tools.FindAsync(id);
            Db.Tools.Remove(tool);
            await Db.SaveChangesAsync();
            //TempData["success"] = "Passenger deleted successfully";
            return RedirectToAction(nameof(Index));
            
        }

        private bool ToolExists(Guid id)
        {
          return (_context.Tools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public override void LoadViewBags()
        {
            LoadAsync();
        }
        public async void LoadAsync()
        {
            ViewBag.Brand = new List<SelectListItem>()
            {
                new SelectListItem("HP", Convert.ToString((int) EBrand.HP)),
                new SelectListItem("DELL", Convert.ToString((int) EBrand.DELL)),
                new SelectListItem("LENOVO", Convert.ToString((int) EBrand.LENOVO)),
                new SelectListItem("APPLE", Convert.ToString((int) EBrand.APPLE))

            };
        }
    }
}
