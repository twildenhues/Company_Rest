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
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
