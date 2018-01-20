using BL.CORE;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BL.CORE.EntityRepository{DAL.DataContext.Ctx.Shift, DAL.DataContext.Ctx.WheelCtx}" />
    /// <seealso cref="BL.Services.Repositories.IShiftRepository" />
    public class ShiftRepository : EntityRepository<Shift, WheelCtx>, IShiftRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftRepository"/> class.
        /// </summary>
        /// <param name="databaseFactory">database factory.</param>
        public ShiftRepository(IDataContextFactory<WheelCtx> databaseFactory) : base(databaseFactory)
        {
        }
    }
}