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
using NHibernate.Criterion;
using NHibernate.Linq;

namespace AccountingWPF.Repositories
{
    public class ExpenditureRepository : MonateryFlowCRUD
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

                Expenditure expenditure = session.Get<Expenditure>(id);
                if (expenditure == null)
                {
                    MessageBox.Show("Expenditure for given id does not exists");
                    return;
                }
                session.Delete(expenditure);
            }

        }

        public MonateryFlow GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<Expenditure>(id);
            }
        }

        public void Update(MonateryFlow monateryFlow)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(monateryFlow);
            }
        }

        public IList<Expenditure> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Query<Expenditure>()
                     .Where(x => x.FK_UserId == userId)
                     .ToList();
            }
        }
    }
}
