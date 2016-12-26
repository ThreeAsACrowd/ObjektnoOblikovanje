using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.Factories;
using AccountingWPF.Models;
using AccountingWPF.nHibernateDb;
using AccountingWPF.Repositories;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using AccountingWPF.Models;

namespace AccountingWPF.Repositories
{
    public class ExpenditureRepository<MonetaryFlow> : IMonetaryFlowRepository<MonetaryFlow>
    {

        private ISessionFactory sessionFactory;
        public ExpenditureRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        public ExpenditureRepository()
        {
            this.sessionFactory = SessionManager.SessionFactory;
        }

        public void Create(MonetaryFlow monetaryFlow)
        {

            using (var session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.SaveOrUpdate(monetaryFlow);
                    transaction.Commit();
                }
            }
        }


        public void Delete(int id)
        {

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Expenditure expenditure = session.Get<Expenditure>(id);

                    if (expenditure == null)
                    {
                        MessageBox.Show("Expenditure for given id does not exists");
                        transaction.Commit();
                        return;
                    }

                    session.Delete(expenditure);
                    transaction.Commit();
                }
            }

        }

        public MonetaryFlow GetById(int id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Expenditure expenditure = session.Get<Expenditure>(id);

                    if (expenditure == null)
                    {
                        transaction.Commit();
                        return default(MonetaryFlow);
                    }


                    Vat vat = session.Get<Vat>(expenditure.FK_VAT);
                    User user = session.Get<User>(expenditure.FK_UserId);

                    expenditure.Vat = vat;
                    expenditure.User = user;

                    MonetaryFlow data = session.Get<MonetaryFlow>(id);
                    transaction.Commit();
                    return data;
                }
            }
        }

        public void Update(MonetaryFlow monetaryFlow)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(monetaryFlow);
                    transaction.Commit();
                }
            }
        }

        public IList<MonetaryFlow> getByUserId(int userId)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<MonetaryFlow> list = (IList<MonetaryFlow>)session.Query<Expenditure>()
                                                                            .Where(x => x.User.Id == userId)
                                                                            .ToList();
                    transaction.Commit();
                    return list;
                }
            }
        }

        public IList<MonetaryFlow> getUserMonetaryFlowByYear(int userId, int year)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<MonetaryFlow> list = (IList<MonetaryFlow>)session.Query<Expenditure>()
                                                                            .Where(x => x.User.Id == userId)
                                                                            .Where(x => x.Date.Year == year)
                                                                            .ToList();
                    transaction.Commit();
                    return list;
                }
            }
        }

        public IList<int> getAvailableYearsByUserId(int userId)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<int> years = session.Query<Expenditure>()
                            .Where(x => x.User.Id == userId)
                            .Select(x => x.Date.Year)
                            .Distinct()
                            .ToList();
                    transaction.Commit();
                    return years;
                }
            }
        }
    }
}
