using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Interfaces
{
	public interface IAddressRepository
	{
		List<Models.Address> ReadAll();
		Models.Address Read(int Id);
		bool DeleteAddress(Models.Address value);
		bool Create(Models.Address value);
		bool Update(Models.Address value);
	}
}
