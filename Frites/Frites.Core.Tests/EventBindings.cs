using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Frites.Core.Tests.Models;
using NHibernate;
using Ninject;
using TechTalk.SpecFlow;

namespace Frites.Core.Tests
{
    [Binding]
    public sealed class EventBindings
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            var sessionFactory = CreateSessionFactory();

            Injector.Kernel.Bind<ISessionFactory>().ToConstant(sessionFactory);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Injector.Kernel.Bind<ISession>().ToMethod(x => Injector.Get<ISessionFactory>().OpenSession()).InThreadScope();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Injector.Get<ISession>().Close();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration =
                MsSqlConfiguration.MsSql2012
                    .ConnectionString(
                        builder => builder
                            .Server(".")
                            .Database("Frites")
                            .TrustedConnection());
            
            return Fluently.Configure()
                .Database(configuration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Item>())
                .BuildSessionFactory();
        }
    }
}
