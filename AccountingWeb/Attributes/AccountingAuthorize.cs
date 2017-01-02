using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataRepository.Models;
using DataRepository.Repositories;
using System.Text;
using AccountingWeb.Security;

namespace AccountingWeb.Attributes
{

	[AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method)]
	public class AccountingAuthorize : AuthorizeAttribute
	{
		//private UserRepository userRepository = new UserRepository();

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{

			//string authHeader = httpContext.Request.Headers["Authorization"];
			//string username = "";
			//string password = "";

			//if (authHeader != null && authHeader.StartsWith("Basic"))
			//{
			//	string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
			//	Encoding encoding = Encoding.GetEncoding("iso-8859-1");
			//	string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

			//	int seperatorIndex = usernamePassword.IndexOf(':');

			//	username = usernamePassword.Substring(0, seperatorIndex);
			//	password = usernamePassword.Substring(seperatorIndex + 1);
			//}
			if(UserManager.CurrentUser != null)
			{
				return true;
			}
			else
			{
				return false;
			}
			//else
			//{
			//	//Handle what happens if that isn't the case
			//	throw new Exception("The authorization header is either empty or isn't Basic.");
			//}

			//if (userRepository.GetUserByCredentials(new UserCredentials(username, password)) != null)
			//{
			//	return true;
			//}
			//else 
			//	return false;
		}
	}
}