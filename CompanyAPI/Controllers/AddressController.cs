using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
	[Route("api/adress")]
	public class AddressController : Controller
	{
		Repository.AddressRepository Address;
		public AddressController()
		{
			Address = new Repository.AddressRepository();
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
