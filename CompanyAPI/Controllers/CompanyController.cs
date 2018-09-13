﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
	[Route("api/company")]
	[ApiController]
	public class CompanyController : Controller
	{
		// GET api/values
		[HttpGet("getall")]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("get/{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost("insert")]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("update/{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}

