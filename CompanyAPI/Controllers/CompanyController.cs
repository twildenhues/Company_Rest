using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
		public IActionResult Get()
		{
			List<Models.Company> dt = Company.ReadCompany();
			return dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult) StatusCode(StatusCodes.Status204NoContent);

		}
		// GET api/company/5
		[HttpGet("get/{id}")]
		public IActionResult Get(int id)
		{
			Models.Company dt = Company.Read(id);
			return dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult) StatusCode(StatusCodes.Status204NoContent);
		}

		// POST api/values
		[HttpPost("insert")]
		public IActionResult Post([FromBody] Models.Company value)
		{
			bool dt = Company.CreatingOrUpdatingCompany(0,value.Name);
			return dt ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult) StatusCode(StatusCodes.Status204NoContent);
		}

		// PUT api/values/5
		[HttpPut("update")]
		public IActionResult Put([FromBody] Models.Company value)
		{
			bool dt = Company.CreatingOrUpdatingCompany(value.Id, value.Name);
			return dt ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult) StatusCode(StatusCodes.Status204NoContent);
		}

		// DELETE api/values/5
		[HttpDelete("delete")]
		public IActionResult Delete([FromBody] Models.Company value)
		{
			bool resval = Company.DeleteCompany(value.Id);
			return resval ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status204NoContent);
		}
	}
}

