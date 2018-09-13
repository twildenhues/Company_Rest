using System;
using System.Data;

namespace CompanyAPI.Models
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime? CreatedTime { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public int Zip { get; set; }
		public string Street { get; set; }
		public string DepartementName { get; set; }
		public int ManagerId { get; set; }

	}
}

