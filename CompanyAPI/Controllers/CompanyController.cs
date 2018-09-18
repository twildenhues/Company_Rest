﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyAPI.Interfaces;

namespace CompanyAPI.Controllers
{
	[Route("api/company")]
	[ApiController]
	public class CompanyController : Controller
	{
		private Helper.Authorization Authorization;
		private ICompanyRepository Company;
		public CompanyController(ICompanyRepository companyRepository) {
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
			string rawString = Request.Headers["Authorization"].ToString();
			var result = Authorization.IsAuthorized(rawString);
			if (result) {
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
							return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
						case UpdateResultType.INVALIDEARGUMENT:
							return StatusCode(StatusCodes.Status409Conflict, "Conflict");
						case UpdateResultType.ERROR:
							return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
						default:
							return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
					}
				}
			} else {
				return StatusCode(StatusCodes.Status401Unauthorized, "You are not allowed to do that!");
			}
		}
		
		// PUT api/values/5
		[HttpPut]
		public IActionResult Put([FromBody] Models.Company value)
		{
			string rawString = Request.Headers["Authorization"].ToString();
			var result = Authorization.IsAuthorized(rawString);
			if (result)
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
							return StatusCode(StatusCodes.Status403Forbidden, "Conflict");
						case UpdateResultType.ERROR:
							return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
						default:
							return StatusCode(StatusCodes.Status406NotAcceptable, "Not Acceptable");
					}
				}
			}
			else {
				return StatusCode(StatusCodes.Status401Unauthorized, "You are not allowed to do that!");
			}
		}
		
		// DELETE api/values/5
		[HttpDelete]
		public IActionResult Delete([FromBody] Models.Company value)
		{
			string rawString = Request.Headers["Authorization"].ToString();
			var result = Authorization.IsAuthorized(rawString);
			if (result)
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
			else {
				return StatusCode(StatusCodes.Status401Unauthorized, "You are not allowed to do that!");
			}
		}
	}
}

