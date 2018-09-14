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
			Company = Repository.CompanyRepository.GetInstance();
		}
		// GET api/company/getall
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				List<Models.Company> dt = Company.ReadCompany();
				var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
				return reval;
			}
			catch (Helper.RepositoryException ex)
			{
				switch (ex.Type) {
					case UpdateResultType.SQLERROR:
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		// GET api/company/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				Models.Company dt = Company.Read(id);
				var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
				return reval;
			}
			catch (Helper.RepositoryException ex)
			{

				switch (ex.Type)
				{
					case UpdateResultType.SQLERROR:
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] Models.Company value)
		{
			try
			{
				bool dt = Company.Create(value);
				var reval = dt ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status204NoContent);
				return reval;
			}
			catch (Helper.RepositoryException ex)
			{

				switch (ex.Type)
				{
					case UpdateResultType.SQLERROR:
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		// PUT api/values/5
		[HttpPut]
		public IActionResult Put([FromBody] Models.Company value)
		{
			try
			{
				bool dt = Company.Update(value);
				var resval = dt ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status204NoContent);
				return resval;
			}
			catch (Helper.RepositoryException ex)
			{

				switch (ex.Type)
				{
					case UpdateResultType.SQLERROR:
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		// DELETE api/values/5
		[HttpDelete]
		public IActionResult Delete([FromBody] Models.Company value)
		{
			try
			{
				bool dt = Company.DeleteCompany(value);
				var resval = dt ? StatusCode(StatusCodes.Status200OK) : StatusCode(StatusCodes.Status204NoContent);
				return resval;
			}
			catch (Helper.RepositoryException ex)
			{

				switch (ex.Type)
				{
					case UpdateResultType.SQLERROR:
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
	}
}

