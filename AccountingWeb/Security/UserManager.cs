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
		private static UserRepository userRepository = new UserRepository();
		public static User CurrentUser;

		public static void LogOut()
		{
			CurrentUser = null;
		}

		public static void LogIn(string username, string password)
		{
			CurrentUser = userRepository.GetUserByCredentials(new UserCredentials(username, password));
		}

		public static bool IsValid(string username, string password)
		{
			
			var user = userRepository.GetUserByCredentials(new UserCredentials(username, password));

			if (user == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}