using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using NHibernate.Id;

namespace AccountingWPF.Helpers
{
    public static class IdentityPartExtensionHelper
    {
        public static void NumericIdentity(this IdentityGenerationStrategyBuilder<IdentityPart> identityBuilder)
        {
            identityBuilder.Custom<IdentityGenerator>();
        }
    }
}
