using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataRepository.nHibernateDb;
using DataRepository.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DataRepository.Models
{
    public class VatRepository : IVatRepository
    {
        private ISessionFactory sessionFactory;
        public VatRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }
        public VatRepository()
        {
            this.sessionFactory = SessionManager.SessionFactory;
        }

        public void Create(Vat vat)
        {
            using (var session = sessionFactory.OpenSession())
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

            using (ISession session = sessionFactory.OpenSession())
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
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(vat);
            }
        }

        public Vat GetById(int id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Vat>(id);
            }
        }

        public IList<Vat> getAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {

                return session.Query<Vat>()
                     .ToList();
            }
        }

    }
}
