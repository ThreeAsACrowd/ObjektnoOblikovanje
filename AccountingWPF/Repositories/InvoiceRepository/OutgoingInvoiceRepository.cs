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
    public class OutgoingInvoiceRepository<Invoice> : IInvoiceRepository<Invoice>
    {
        public void Create(Invoice invoice)
        {
            using (var session = SessionManager.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(invoice);
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {

                Invoice invoice = session.Get<Invoice>(id);
                if (invoice == null)
                {
                    MessageBox.Show("Invoice for given id does not exists");
                    return;
                }
                session.Delete(invoice);
            }
        }

        public Invoice GetById(int id)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return session.Get<Invoice>(id);
            }
        }

        public void Update(Invoice invoice)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                session.Update(invoice);
            }
        }

        public IList<Invoice> getByUserId(int userId)
        {
            using (ISession session = SessionManager.OpenSession())
            {
                return (IList<Invoice>)session.Query<OutgoingInvoice>()
                     .Where(x => x.FK_UserId == userId)
                     .ToList();
            }
        }
    }
}
