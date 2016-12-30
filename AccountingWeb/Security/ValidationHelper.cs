using System;
using System.Web;

namespace AccountingWeb.Security
{
    public class ValidationHelper
    {

        public static int PASSWORD_MIN_LENGTH = 4;
        public static int USERNAME_MIN_LENGTH = 4;


        public static bool IsCredentialsValid(string username, string password)
        {
            return isPasswordValid(password) && isUsernameValid(username);
        }
        private static bool isUsernameValid(String username)
        {
            return username.Length >= USERNAME_MIN_LENGTH;
        }

        private static bool isPasswordValid(String password)
        {
            return password.Length >= PASSWORD_MIN_LENGTH;
        }

    }
}
