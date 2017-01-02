using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace DataRepository.Models.nHibernateModels
{
    public class IngoingInvoiceMap : SubclassMap<IngoingInvoice>
    {
        public IngoingInvoiceMap()
        {
            Map(x => x.SupplierInfo);
        }
    }
}
