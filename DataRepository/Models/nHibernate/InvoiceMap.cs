
using FluentNHibernate.Mapping;

namespace DataRepository.Models.nHibernateModels
{
    public class InvoiceMap : ClassMap<Invoice>
    {
        public InvoiceMap()
        {

            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Date);
            Map(x => x.Amount);
            Map(x => x.InvoiceClassNumber);
            References(c => c.User).Column("FK_UserId").Not.LazyLoad();
            Map(x => x.FK_UserId).Formula("[FK_UserId]");
            UseUnionSubclassForInheritanceMapping();
        }

    }
}
