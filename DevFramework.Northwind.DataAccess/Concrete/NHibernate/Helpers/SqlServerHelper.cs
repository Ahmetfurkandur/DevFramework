using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.Concrete.NHibernate;
using DevFramework.Core.DataAccess.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using  NHibernate;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper:NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012//MssqlConfiguration
                .ConnectionString(c=> c.FromConnectionStringWithKey(@"Northwind")))//FluentConfiguration
                .Mappings(t=>t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))//FluentConfiguration
                .BuildSessionFactory();
        }
    }
}
