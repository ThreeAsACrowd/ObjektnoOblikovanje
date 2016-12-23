using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class VatMap : ClassMap<VAT>
    {

        public VatMap()
        {

            Id(x => x.Id).GeneratedBy.Native().Unique();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Percentage).Not.Nullable();

           Table("VAT");
        }
    }
}
