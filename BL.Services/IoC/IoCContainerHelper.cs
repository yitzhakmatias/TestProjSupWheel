using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BL.CORE;
using BL.Services.Repositories;
using DAL.DataContext;

namespace BL.Services.IoC
{
    public static class IoCContainerHelper
    {

        public static ContainerBuilder BuilderHelper(this ContainerBuilder builder)
        {
            builder.Register<IDataContextFactory<WheelContext>>(x => new DefaultDataContextFactory<WheelContext>()).InstancePerLifetimeScope();

            builder.Register<IEngineerRepository>(x => new EngineerRepository(x.Resolve<IDataContextFactory<WheelContext>>())).SingleInstance();
            builder.Register<IShiftRepository>(x => new ShiftRepository(x.Resolve<IDataContextFactory<WheelContext>>())).SingleInstance();
            builder.Register<ITaskRepository>(x => new TaskRepository(x.Resolve<IDataContextFactory<WheelContext>>())).SingleInstance();

            builder.Register<IUnitOfWork>(x => new UnitOfWork<WheelContext>(x.Resolve<IDataContextFactory<WheelContext>>())).SingleInstance();

            return builder;
        }
    }
}
