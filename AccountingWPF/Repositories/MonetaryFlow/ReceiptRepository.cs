using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.Factories;
using AccountingWPF.Models;
using AccountingWPF.nHibernateDb;
using NHibernate;
using NHibernate.Linq;

namespace AccountingWPF.Repositories
{
    public class ReceiptRepository<MonetaryFlow> : IMonetaryFlowRepository<MonetaryFlow>
    {

        public void Create(MonetaryFlow monetaryFlow)
        {
            using (var session = SessionManager.OpenSession())
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
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Receipt expenditure = session.Get<Receipt>(id);
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

        public void Update(MonetaryFlow monetaryFlow)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(monetaryFlow);
                    transaction.Commit();
                }
            }
        }

        public MonetaryFlow GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    MonetaryFlow receipt = session.Get<MonetaryFlow>(id);
                    transaction.Commit();
                    return receipt;
                }
            }
        }

        public IList<MonetaryFlow> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<MonetaryFlow> list = (IList<MonetaryFlow>)session.Query<Receipt>()
                                                                         .Where(x => x.User.Id == userId)
                                                                         .ToList();
                    transaction.Commit();
                    return list;
                }
            }
        }

        public IList<MonetaryFlow> getUserMonetaryFlowByYear(int userId, int year)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<MonetaryFlow> list = (IList<MonetaryFlow>)session.Query<Receipt>()
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
            using (ISession session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<int> years = session.Query<Receipt>()
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
