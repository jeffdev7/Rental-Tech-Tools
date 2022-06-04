using JagoRTT.Infrastructure.DBConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace JagoRTT.UI.Controllers
{
    public abstract class BaseController<TViewModel> : Controller where TViewModel 
        : class, new()
    {
        protected readonly ApplicationContext Db;

        public BaseController(ApplicationContext db)
        {
            Db = db;
        }

        public abstract IEnumerable<TViewModel> GetRows();
        public abstract TViewModel GetRow(Guid id);

        public abstract void LoadViewBags();
    }
}