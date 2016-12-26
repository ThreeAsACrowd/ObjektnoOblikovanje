using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace AccountingWPF.nHibernateDb
{
    public abstract class AbstractSessionManager
    {

        public abstract ISession OpenSession();
    }
}
