using AccountingWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingWPF.Repositories;

namespace AccountingWPF.BaseLib
{
    public static class UserManager
    {
        public static User CurrentUser;

        public static void LogOut()
        {
            CurrentUser = null;
        }

        public static void LogIn(User user)
        {
            CurrentUser = user;
        }
    }
}
