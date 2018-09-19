using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyAPI.Interfaces;
using TobitWebApiExtensions.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using TobitLogger;
using TobitLogger.Core;

namespace CompanyAPI.Controllers
{
	[Route("api/company")]
	[ApiController]
	public class CompanyController : Controller
	{
		private Helper.Authorization Authorization;
		private readonly ILogger<CompanyController> logger;
		private ICompanyRepository Company;
		public CompanyController(ICompanyRepository companyRepository, ILoggerFactory loggerFactory) {
			logger = loggerFactory.CreateLogger<CompanyController>();
			Company = companyRepository;
			Authorization = new Helper.Authorization();
		}
		
		// GET api/company/getall
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				List<Models.Company> dt = Company.ReadAll();
				var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
				return reval;
			}
			catch (Helper.RepositoryException ex)
			{
				switch (ex.Type) {
					case UpdateResultType.SQLERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						logger.Error(ex.ErrorMsg);
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
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		
		// POST api/values
		[HttpPost]
		[Authorize(Roles ="1")]
		public IActionResult Post([FromBody] Models.Company value)
		{
			try
			{
				bool dt = Company.Create(value);
				var reval = dt ? StatusCode(StatusCodes.Status200OK) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
				return reval;
			}
			catch (Helper.RepositoryException ex)
			{

				switch (ex.Type)
				{
					case UpdateResultType.SQLERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		
		// PUT api/values/5
		[HttpPut]
		[Authorize(Roles = "1")]
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
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status403Forbidden, "Conflict");
					case UpdateResultType.ERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
		
		// DELETE api/values/5
		[HttpDelete]
		[Authorize(Roles = "1")]
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
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
					case UpdateResultType.INVALIDEARGUMENT:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status409Conflict, "Conflict");
					case UpdateResultType.ERROR:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
					default:
						logger.Error(ex.ErrorMsg);
						return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
				}
			}
		}
	}
}

