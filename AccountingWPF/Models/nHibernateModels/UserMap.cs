
using AccountingWPF.Helpers;
using FluentNHibernate.Mapping;

namespace AccountingWPF.Models.nHibernateModels
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {

            Table("User");

            Id(x => x.Id).GeneratedBy.Native().Unique();
            Map(x => x.Username).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Email).Nullable();
            Map(x => x.Address).Nullable();
            Map(x => x.AssociationName).Nullable();
            Map(x => x.OIB).Nullable();

        }

    }
}
