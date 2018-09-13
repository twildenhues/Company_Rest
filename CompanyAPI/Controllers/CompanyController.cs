using System;
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
		Repository.CompanyRepository Company;
		public CompanyController() {
			Company = new Repository.CompanyRepository();
		}
		// GET api/company/getall
		[HttpGet("getall")]
		public List<Models.Company> Get()
		{
			List<Models.Company> dt = Company.ReadCompany();
			return dt;

		}
		// GET api/company/5
		[HttpGet("get/{id}")]
		public Models.Company Get(int id)
		{
			Models.Company dt = Company.Read(id);
			return dt;
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

