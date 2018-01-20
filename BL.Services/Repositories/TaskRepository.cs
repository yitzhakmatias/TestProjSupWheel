using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BL.CORE.EntityRepository{DAL.DataContext.Ctx.TaskEngineer, DAL.DataContext.Ctx.WheelCtx}" />
    /// <seealso cref="BL.Services.Repositories.ITaskRepository" />
    public class TaskRepository :EntityRepository<TaskEngineer, WheelCtx>, ITaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="databaseFactory">database factory.</param>
        public TaskRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}