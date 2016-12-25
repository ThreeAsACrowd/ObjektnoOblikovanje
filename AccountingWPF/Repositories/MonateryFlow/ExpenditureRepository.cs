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
    public class ExpenditureRepository<MonateryFlow> : MonateryFlowRepository<MonateryFlow>
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
                Expenditure expenditure = session.Get<Expenditure>(id);


                if (expenditure == null)
                {
                    return default(MonateryFlow);
                }


                Vat vat = session.Get<Vat>(expenditure.FK_VAT);
                User user = session.Get<User>(expenditure.FK_UserId);

                expenditure.Vat = vat;
                expenditure.User = user;

                return session.Get<MonateryFlow>(id);
            }
        }

        public void Update(MonateryFlow monateryFlow)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(monateryFlow);
            }
        }

        public IList<MonateryFlow> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return (IList<MonateryFlow>)session.Query<Expenditure>()
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

                return session.Query<Expenditure>()
                            .Where(x => x.User.Id == userId)
                            .Select(x => x.Date.Year)
                            .Distinct()
                            .ToList();
            }
        }
    }
}
