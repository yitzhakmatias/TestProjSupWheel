using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BL.CORE.EntityRepository{DAL.DataContext.Ctx.Engineer, DAL.DataContext.Ctx.WheelCtx}" />
    /// <seealso cref="BL.Services.Repositories.IEngineerRepository" />
    public class EngineerRepository : EntityRepository<Engineer, WheelCtx>, IEngineerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineerRepository"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        public EngineerRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}