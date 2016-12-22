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
using AccountingWPF.nHibernateDb;
using AccountingWPF.Repositories;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;

namespace AccountingWPF.Repositories
{
    public class UserRepository
    {
        /*
        public static void abstractCreateUser(User user)
        {
            ISession mySession = Database.OpenSession();
            using (RepositoryBase repository = new RepositoryBase())
            {
                try
                {
                    repository.Save(user);
                    repository.CommitTransaction();

                }
                catch
                {
                    repository.RollbackTransaction();
                }
            }
        }

        public static User absractGetUserByCredentials(UserCredentials userCredentials)
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
                // MessageBox.Show("User " + user.Username + " exists!");
                return user;
            }
        }*/

        

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        public static void CreateNewUser(User user)
        {
            using (var session = Database.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(user);
                    transaction.Commit();
                    //MessageBox.Show("Created user: " + user.Username);
                }

            }
        }

        public static User GetUserById(int id)
        {
            using (ISession session = Database.OpenSession())
            {

                var users = session.CreateCriteria<User>()
                 .Add(Restrictions.Eq("Id", id))
                                   .List<User>();

                if (users.Count() == 0)
                {
                    MessageBox.Show("User does not exists!");
                    return null;
                }
                User user = users[0];
                //Console.WriteLine("User with id: " + id + "  exists!");
                return user;
            }
        }

        public static User GetUserByCredentials(UserCredentials userCredentials)
        {
            using (ISession session = Database.OpenSession())
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
                // MessageBox.Show("User " + user.Username + " exists!");
                return user;
            }
        }

        public static User UpdateUser(User user)
        {
            using (ISession session = Database.OpenSession())
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
