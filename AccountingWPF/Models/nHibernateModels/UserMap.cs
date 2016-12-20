
using AccountingWPF.Helpers;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {

            Table("User");

            Id(x => x.Id).Column("Id").GeneratedBy.Increment();
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.Email);
            Map(x => x.Address);
            Map(x => x.AssociationName);
            Map(x => x.OIB);

        }

    }
}
