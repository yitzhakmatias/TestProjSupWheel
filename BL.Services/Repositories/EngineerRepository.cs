using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    public class EngineerRepository : EntityRepository<Engineer, WheelCtx>, IEngineerRepository
    {
        public EngineerRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}