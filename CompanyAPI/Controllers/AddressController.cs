using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CompanyAPI.Interfaces;

namespace CompanyAPI.Controllers
{
	[Route("api/address")]
	public class AddressController : Controller
	{
		private IAddressRepository Address;
		public AddressController(IAddressRepository AddressRepository)
		{
			Address = AddressRepository;
		}
		// GET: api/<controller>
		[HttpGet]
		public IActionResult Get()
		{
			List<Models.Address> dt = Address.ReadAddress();
			var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return reval;
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			Models.Address dt = Address.Read(id);
			var reval = dt != null ? StatusCode(StatusCodes.Status200OK, dt) : (IActionResult)StatusCode(StatusCodes.Status204NoContent);
			return reval;
		}

		// POST api/<controller>
		[HttpPost]
		public IActionResult Post([FromBody] Models.Address value)
		{
			try
			{
				bool dt = Address.Create(value);
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
		public IActionResult Put([FromBody] Models.Address value)
		{
			try
			{
				bool dt = Address.Update(value);
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
		public IActionResult Delete([FromBody] Models.Address value)
		{
			try
			{
				bool dt = Address.DeleteAddress(value);
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
