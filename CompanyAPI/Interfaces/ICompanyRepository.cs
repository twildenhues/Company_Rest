using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPI.Interfaces
{
	public interface ICompanyRepository
	{
		List<Models.Company> ReadAll();
		Models.Company Read(int i);
		bool DeleteCompany(Models.Company value);
		bool Create(Models.Company value);
		bool Update(Models.Company value);

	}
}
