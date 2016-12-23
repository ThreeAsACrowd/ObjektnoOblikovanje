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
    public class ReceiptRepository<MonateryFlow> : MonateryFlowCRUD<MonateryFlow>
    {

        public void Create(MonateryFlow monateryFlow)
        {
            using (var session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(monateryFlow);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {

                Receipt expenditure = session.Get<Receipt>(id);
                if (expenditure == null)
                {
                    MessageBox.Show("Expenditure for given id does not exists");
                    return;
                }
                session.Delete(expenditure);
            }
        }

        public void Update(MonateryFlow monateryFlow)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(monateryFlow);
            }
        }

        public MonateryFlow GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<MonateryFlow>(id);
            }
        }

        public IList<MonateryFlow> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return (IList<MonateryFlow>)session.Query<Receipt>()
                     .Where(x => x.User.Id == userId)
                     .ToList();
            }
        }

        public IList<MonateryFlow> getUserMonateryFlowByYear(int userId, int year)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return (IList<MonateryFlow>)session.Query<Expenditure>()
                     .Where(x => x.User.Id == userId)
                     .Where(x => x.Date.Year == year)
                     .ToList();
            }
        }

        public IList<int> getAvailableYearsByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {

                return session.Query<Receipt>()
                            .Where(x => x.User.Id == userId)
                            .Select(x => x.Date.Year)
                            .Distinct()
                            .ToList();
            }
        }
    }
}
