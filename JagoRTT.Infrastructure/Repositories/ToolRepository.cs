using JagoRTT.domain.Entities;
using JagoRTT.domain.Interfaces.Repositories;
using JagoRTT.Infrastructure.DBConfiguration;

namespace JagoRTT.Infrastructure.Repositories
{
    public class ToolRepository : Repository<Tool>, IToolRepository
    {
        public ToolRepository(ApplicationContext context): base(context) { }
        public IQueryable<Tool> GetTools()
        {
            return Db.Tools;
        }
    }
}
