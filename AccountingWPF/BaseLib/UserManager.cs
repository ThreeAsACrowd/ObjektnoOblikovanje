
using DataRepository.Models;

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
