﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public int Zip { get; set; }
		public string Street { get; set; }
		public DateTime? CreatedTime { get; set; }
		public DateTime? DeletedTime { get; set; }
		public int compId { get; set; }
		public int empId { get; set; }
	}
}
