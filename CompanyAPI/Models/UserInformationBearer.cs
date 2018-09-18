using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
	public class UserInformationBearer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PersonID { get; set; }
		public string jti { get; set; }

	}
}
