using DataRepository.Models;
using DataRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingWeb.Security
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