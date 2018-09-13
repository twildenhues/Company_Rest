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
		[HttpGet]
		public IActionResult Get()
		{
			List<Models.Company> dt = Company.ReadCompany();
			var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return reval;

		}
		// GET api/company/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			Models.Company dt = Company.Read(id);
			var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return reval;
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] Models.Company value)
		{
			bool dt = Company.CreatingOrUpdatingCompany(0,value.Name);
			var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return reval;
		}

		// PUT api/values/5
		[HttpPut]
		public IActionResult Put([FromBody] Models.Company value)
		{
			bool dt = Company.CreatingOrUpdatingCompany(value.Id, value.Name);
			var resval = dt ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return resval;
		}

		// DELETE api/values/5
		[HttpDelete]
		public IActionResult Delete([FromBody] Models.Company value)
		{
			bool dt = Company.DeleteCompany(value.Id);
			var resval = dt? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status204NoContent);
			return resval;
		}
	}
}

