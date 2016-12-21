using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.BindingModels;
using AccountingWPF.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace AccountingWPF.Respositories
{
    class UserRepository
    {

        public static ISession OpenSession()
        {
            //TODO nastimat svoju putanju


            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mvukosav\Documents\Visual Studio 2015\Projects\ObjektnoOblikovanje\Database\Database.mdf;Integrated Security=True";


            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString)
                .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
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
        public static string CreateNewUser(User user)
        {
            using (var session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Save(user);
                    transaction.Commit();
                }
                return "user created";

                Console.WriteLine("Created user: " + user.Username);
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

                IQuery query = session.CreateQuery("from User where username=" + userCredentials.Username + " AND password=" + userCredentials.Password);
                User user = query.List<User>()[0];
                if (user == null)
                {
                    Console.WriteLine("User " + user + " does not exists!");
                }
                else
                {
                    Console.WriteLine("User " + user + " exists!");
                }

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
