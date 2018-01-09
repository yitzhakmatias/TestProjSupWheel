using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    public class TaskRepository :EntityRepository<TaskEngineer, WheelCtx>, ITaskRepository
    {
        public TaskRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}