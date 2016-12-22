using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Models;

namespace AccountingWPF.Factories
{
    static class Mock
    {


        public static User getUser()
        {
            User user = new User();
            user.Username = "marko";
            user.Password = "pass";
            user.OIB = "123141";
            user.Address = "Unska 3";
            user.Email = "mojemail@email.com";
            user.AssociationName = "udruga";

            return user;
        }

    }
}
