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

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        public static void Create(User user)
        {
            using (var session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(user);
                    transaction.Commit();
                    //MessageBox.Show("Created user: " + user.Username);
                }

            }
        }

        public static User GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<User>(id);
            }
        }

        public static User GetUserByCredentials(UserCredentials userCredentials)
        {
            using (ISession session = SessionManager.OpenSession())
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

        public static void UpdateUser(User user)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(user);
            }
        }

        public static void DeleteUser(User user)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Delete(user);
            }
        }

    }
}
