using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace CompanyAPI.Helper {
	class Authorization
	{
		public bool IsAuthorized(string code) {
			if (code != "")
			{
				string decodedString = code.Split(" ")[1];
				string credentials = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(decodedString));
				int separatorIndex = credentials.IndexOf(':');
				if (separatorIndex >= 0)
				{
					string userName = credentials.Substring(0, separatorIndex);
					string password = credentials.Substring(separatorIndex + 1);
					if (userName == "tim" && password == "123456")
					{
						return true;
					}
					else {
						return false;
					}
				}
				else {
					return false;
				}
			}
			else {
				return false;
			}
		}
	}
}