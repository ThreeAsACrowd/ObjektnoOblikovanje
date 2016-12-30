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
		private static UserRepository userRepository;
		public static User CurrentUser;

		public static void LogOut()
		{
			CurrentUser = null;
		}

		public static void LogIn(string username, string password)
		{
			userRepository = new UserRepository();
			CurrentUser = userRepository.GetUserByCredentials(new UserCredentials(username, password));
		}

		public static bool IsValid(string username, string password)
		{
			userRepository = new UserRepository();
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