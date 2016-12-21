using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.BindingModels;
using AccountingWPF.Models;
using AccountingWPF.Models.nHibernateModels;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

namespace AccountingWPF.Respositories
{
    class UserRepository
    {
        static ISessionFactory sessionFactory;
        public static ISession OpenSession()
        {
            //TODO nastimat svoju putanju
            //  string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mvukosav\Documents\Visual Studio 2015\Projects\ObjektnoOblikovanje\Database\Database.mdf;Integrated Security=True";
            //string conn = @"Data Source=C:\Users\mvukosav\Documents\Visual Studio 2015\Projects\ObjektnoOblikovanje\Database\accountingDB.db";
			string conn = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\Database\accountingDB.db";
            if (sessionFactory == null)
            {
                sessionFactory = Fluently.Configure()
                   .Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("accountingDB.db"))
                   //.Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey(conn)))
                   //.Database(MsSqlConfiguration.MsSql2012
                   //.ConnectionString(conn)
                   //.ShowSql())
                   .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                   // .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                   .ExposeConfiguration(BuildSchema)
                   .BuildSessionFactory();
            }
            return sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            // if (File.Exists("accountingDB.db"))
            //    File.Delete("accountingDB.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            if (File.Exists("accountingDB.db"))
            {
                new SchemaExport(config)
                  .Create(false, true);
            }
        }

        public static User getMockUser()
        {
            User user = new User();
            user.Username = "marko";
            user.Password = "pass";
            user.OIB = "123141";
            user.Address = "Unska 3";
            user.Email = "mojemail@email.com";
            user.AssociationName = "udruga";

            return user;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        public static void CreateNewUser(User user)
        {
            using (var session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(user);
                    transaction.Commit();
                    MessageBox.Show("Created user: " + user.Username);
                }

            }
        }

        public static User GetUserById(int id)
        {
            using (ISession session = OpenSession())
            {

                IQuery query = session.CreateQuery("from User where userId=" + id);
                User user = query.List<User>()[0];
                if (user == null)
                {
                    Console.WriteLine("User with id: " + id + " does not exists!");
                }
                else
                {
                    Console.WriteLine("User with id: " + id + "  exists!");
                }

                return user;
            }
        }

        public static User GetUserByCredentials(UserCredentials userCredentials)
        {
            using (ISession session = OpenSession())
            {
                var users = session.CreateCriteria<User>()
                  .Add(Restrictions.Eq("Username", userCredentials.Username))
                                    .Add(Restrictions.Eq("Password", userCredentials.Password))
                                    .List<User>();

                if (users.Count() == 0)
                {
                    MessageBox.Show("User does not exists!");
                    return null;
                }
                User user = users[0];
                MessageBox.Show("User " + user.Username + " exists!");
                return user;
            }
        }

        public static User UpdateUser(User user)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    IQuery query = session.CreateQuery("from User where userId=" + user.Id);
                    User oldUser = query.List<User>()[0];

                    if (oldUser == null)
                    {
                        Console.WriteLine("User " + user.Username + " does not exists!");
                    }
                    else
                    {
                        oldUser = user;
                        session.Flush();
                        transaction.Commit();
                        Console.WriteLine("User " + user.Username + "  is updated!");
                    }
                    return oldUser;
                }
            }
        }





    }
}
