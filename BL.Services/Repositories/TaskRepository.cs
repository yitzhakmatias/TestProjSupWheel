using BL.CORE;
using DAL.DataContext;

namespace BL.Services.Repositories
{
    public class TaskRepository :EntityRepository<TaskEngineer, WheelContext>, ITaskRepository
    {
        public TaskRepository(IDataContextFactory<WheelContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}