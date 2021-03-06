﻿using Autofac;
using EFDI.Data;
using EFDI.Service;

namespace EFDI.DI.Core
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>();
            base.Load(builder);
        }
    }
}