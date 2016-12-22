using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class MonateryFlowMap : ClassMap<MonateryFlow>
    {

        public MonateryFlowMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Date);
            Map(x => x.AmountCash);
            Map(x => x.AmountNonCashBenefit);
            Map(x => x.AmountTransferAccount);
            //pogledat kako rjesit foreign keyeve
            Map(x => x.FK_UserId).Not.Nullable();
            Map(x => x.FK_VAT).Not.Nullable();
            Map(x => x.JournalEntryNum);
            Map(x => x.Total);

            UseUnionSubclassForInheritanceMapping();
        }

    }
}
