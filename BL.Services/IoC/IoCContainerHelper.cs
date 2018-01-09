using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BL.CORE;
using BL.Services.Repositories;
using BL.Services.Rules;
using DAL.DataContext;
using DAL.DataContext.Ctx;

namespace BL.Services.IoC
{

    public static class IoCContainerHelper
    {
        private static readonly IContainer Container;

        static IoCContainerHelper()
        {
            var builder = new ContainerBuilder();

            builder.Register<IDataContextFactory<WheelCtx>>(x => new DefaultDataContextFactory<WheelCtx>()).InstancePerLifetimeScope();

            builder.Register<IEngineerRepository>(x => new EngineerRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<IShiftRepository>(x => new ShiftRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<ITaskRepository>(x => new TaskRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<ITaskRule>(x => new TaskRule(
                x.Resolve<IEngineerRepository>(),
                x.Resolve<ITaskRepository>(),
                x.Resolve<IShiftRepository>(),
                x.Resolve<IUnitOfWork>()
                )).SingleInstance();

            builder.Register<IUnitOfWork>(x => new UnitOfWork<WheelCtx>(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();

            Container = builder.Build();
        }

        public static ContainerBuilder BuilderHelper(this ContainerBuilder builder)
        {

            builder.Register<IDataContextFactory<WheelCtx>>(x => new DefaultDataContextFactory<WheelCtx>()).InstancePerLifetimeScope();

            builder.Register<IEngineerRepository>(x => new EngineerRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<IShiftRepository>(x => new ShiftRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<ITaskRepository>(x => new TaskRepository(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();
            builder.Register<ITaskRule>(x => new TaskRule(
                x.Resolve<IEngineerRepository>(),
                x.Resolve<ITaskRepository>(),
                x.Resolve<IShiftRepository>(),
                x.Resolve<IUnitOfWork>()
            )).SingleInstance();

            builder.Register<IUnitOfWork>(x => new UnitOfWork<WheelCtx>(x.Resolve<IDataContextFactory<WheelCtx>>())).SingleInstance();

            return builder;
        }
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
