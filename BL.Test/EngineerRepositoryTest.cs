using System.Linq;
using BL.Services.IoC;
using BL.Services.Repositories;
using DAL.DataContext;
using DAL.DataContext.Ctx;
using Xunit;

namespace BL.Test
{
    public class EngineerRepositoryTest
    {


        [Fact]
        public void GetAllEngineersTest()
        {
            var ioc = IoCContainerHelper.Resolve<IEngineerRepository>();

            //IEngineerRepository EngineerRepository = new EngineerRepository();
            //var context = new WheelContext();

            var data1 = ioc.GetMany(p => p.EngineerId != 0);

            var dc = new WheelCtx();
            var data = dc.Engineers.Where(p => p.EngineerId >0).ToList();
        }
    }
}
