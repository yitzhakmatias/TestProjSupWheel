using BL.CORE;
using DAL.DataContext;

namespace BL.Services.Repositories
{
    public class ShiftRepository : EntityRepository<Shift, WheelContext>, IShiftRepository
    {
        public ShiftRepository(IDataContextFactory<WheelContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}