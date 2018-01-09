using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    public class ShiftRepository : EntityRepository<Shift, WheelCtx>, IShiftRepository
    {
        public ShiftRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}