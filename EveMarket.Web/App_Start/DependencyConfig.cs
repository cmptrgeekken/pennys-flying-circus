using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using eZet.EveLib.EveAuthModule;
using eZet.EveLib.EveCrestModule;
using EveMarket.Core.Repositories;
using EveMarket.Core.Services;
using EveMarket.Core.Services.Interfaces;
using LiteDB;

namespace EveMarket.Web
{
    public class DependencyConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(DependencyConfig).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            RegisterTypes(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

            builder.RegisterType<LiteDatabase>()
                .WithParameter("connectionString", $@"{dataDirectory}\FlyingCircus.db")
                .AsSelf();

            builder.RegisterType<EveDb>()
                .AsSelf();

            builder.RegisterType<ItemService>()
                .As<IItemService>();

            builder.RegisterType<PlayerService>()
                .As<IPlayerService>();

            builder.RegisterType<EveAuth>()
                .AsSelf();

            builder.RegisterType<EveCrest>()
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<EveService>()
                .As<IEveService>();

            builder.RegisterType<TaskConfig>()
                .AsSelf();
        }
    }

    
}