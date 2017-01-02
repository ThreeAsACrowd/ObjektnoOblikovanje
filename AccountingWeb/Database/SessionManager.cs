using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AccountingWeb.Database
{
    public static class SessionManager
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory {
            get {
                if (sessionFactory == null)
                {

                    string conn = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"../AccountingWPF/bin/Debug/accountingDB.db";

                    sessionFactory = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.ConnectionString(conn))
                     .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    //  .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(DataRepository.nHibernateDb.SessionManager))))
                    // .Mappings(m => m.AutoMappings.Add(CreateMappings()))
                    // .ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
                }
                return sessionFactory;
            }
        }

        // Returns our mappings
        private static AutoPersistenceModel CreateMappings()
        {
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetAssembly(typeof(DataRepository.App)))
                .Where(t => t.Namespace == "DataRepository.Models")
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }


        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists("accountingDB.db"))
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
