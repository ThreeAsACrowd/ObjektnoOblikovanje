
using AccountingWPF.Helpers;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class InvoicesMap : ClassMap<Invoice>
    {
        public InvoicesMap()
        {

            Id(x => x.Id).Column("Id").GeneratedBy.Increment();
            Map(x => x.Date);
            Map(x => x.Amount);
            Map(x => x.InvoiceClassNumber);
            Map(x => x.FK_UserId);

            UseUnionSubclassForInheritanceMapping();
        }

    }
}
