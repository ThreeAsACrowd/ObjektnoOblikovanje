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
    public class VATRepository : IVatRepository
    {

        public void Create(VAT vat)
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
                VAT vat = session.Get<VAT>(id);
                if (vat == null)
                {
                    MessageBox.Show("VAT for given id does not exists");
                    return;
                }
                session.Delete(vat);
            }

        }

        public void Update(VAT vat)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(vat);
            }
        }

        public VAT GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<VAT>(id);
            }
        }

        public IList<VAT> getAll()
        {
            using (ISession session = SessionManager.OpenSession())
            {

                return session.Query<VAT>()
                     .ToList();
            }
        }

    }
}
