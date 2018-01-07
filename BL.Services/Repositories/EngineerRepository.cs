using BL.CORE;
using DAL.DataContext;

namespace BL.Services.Repositories
{
    public class EngineerRepository : EntityRepository<Engineer, WheelContext>, IEngineerRepository
    {
        public EngineerRepository(IDataContextFactory<WheelContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}