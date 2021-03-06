﻿using System;
using System.Data;

namespace CompanyAPI.Models
{
	public class Company : Dto.CompanyDto
	{
		public DateTime? CreatedTime { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public int Zip { get; set; }
		public string Street { get; set; }
		public string DepartementName { get; set; }
		public int ManagerId { get; set; }
		public DateTime? DeletedTime { get; set; }

	}
}

