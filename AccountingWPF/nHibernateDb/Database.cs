using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AccountingWPF.nHibernateDb
{
    public static class SessionManager
    {
        private static ISessionFactory sessionFactory;
        private static ISessionFactory SessionFactory {
            get {
                if (sessionFactory == null)
                {

                    sessionFactory = Fluently.Configure()
                   .Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("accountingDB.db"))
                   .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                   //.ExposeConfiguration(BuildSchema)
                   .BuildSessionFactory();
                }
                return sessionFactory;
            }
        }


        private static void BuildSchema(Configuration config)
        {
            if (File.Exists("accountingDB.db"))
            {
                new SchemaExport(config).Create(false, true);
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }



    }
}
