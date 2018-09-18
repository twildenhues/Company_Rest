using System;
using System.Text;
using CompanyAPI.Models;
using Newtonsoft.Json;

namespace CompanyAPI.Helper {
	class Authorization
	{
		public bool IsAuthorized(string code) {
			if (code != "")
			{
				switch (code.Split(" ")[0])
				{
					case "Basic": 
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
							else
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					case "bearer":
						string decodedStringBearer = (code.Split(" ")[1]).Split(".")[1];

						if (decodedStringBearer.Length % 4 == 1) decodedStringBearer = decodedStringBearer + "===";
						if (decodedStringBearer.Length % 4 == 2) decodedStringBearer = decodedStringBearer + "=="; 
						if (decodedStringBearer.Length % 4 == 3) decodedStringBearer = decodedStringBearer + "=";

						string credentialsBearer = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(decodedStringBearer));
						var model = JsonConvert.DeserializeObject<UserInformationBearer>(credentialsBearer);

						if (model != null)
						{
							string LastName = model.LastName;
							string FirstName = model.FirstName;
							string PersonID = model.PersonID;
							string jti = model.jti;

							if (LastName == "Wildenhues" && FirstName == "Tim")
							{
								return true;
							}
							else
							{
								return false;
							}
						}
						else
						{
							return false;
						}
					default: return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}