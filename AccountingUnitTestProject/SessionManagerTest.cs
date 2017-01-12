using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

public static class SessionManagerTest
{
    private static ISessionFactory sessionFactory;
    public static ISessionFactory SessionFactory {
        get {
            if (sessionFactory == null)
            {

                sessionFactory = Fluently.Configure()
               .Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("accountingDBtest.db"))
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataRepository.Models.Invoice>())
               .ExposeConfiguration(BuildSchema)
               .BuildSessionFactory();
            }
            return sessionFactory;
        }
    }


    private static void BuildSchema(Configuration config)
    {
        new SchemaExport(config).Create(false, true);
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }



}

