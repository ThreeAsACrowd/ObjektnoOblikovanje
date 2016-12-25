using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccountingWPF.nHibernateDb;
using AccountingWPF.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace AccountingWPF.Models
{
    public class VatRepository : IVatRepository
    {

        public void Create(Vat vat)
        {
            using (var session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(vat);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {

            using (ISession session = SessionManager.OpenSession())
            {
                Vat vat = session.Get<Vat>(id);
                if (vat == null)
                {
                    MessageBox.Show("VAT for given id does not exists");
                    return;
                }
                session.Delete(vat);
            }

        }

        public void Update(Vat vat)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(vat);
            }
        }

        public Vat GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<Vat>(id);
            }
        }

        public IList<Vat> getAll()
        {
            using (ISession session = SessionManager.OpenSession())
            {

                return session.Query<Vat>()
                     .ToList();
            }
        }

    }
}
