using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using CompanyAPI.Interfaces;

namespace CompanyAPI.Repository
{
	class AddressRepository : IAddressRepository
	{
		IDbContext _dbContext;
		public AddressRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public List<Models.Address> ReadAddress()
		{
			var conn = _dbContext.GetConnection();
			string sqlcmd = "SELECT Id, Country, City, Zip, Street, CreatedTime FROM viAddress";
			var test = conn.Query<Models.Address>(sqlcmd).ToList();
			return test;
		}
		public Models.Address Read(int Id)
		{
			var conn = _dbContext.GetConnection();
			string sqlcmd = "SELECT Id, Country, City, Zip, Street, CreatedTime FROM viAddress FROM viAddress where Id = @Id";
			var param = new DynamicParameters();
			param.Add("@Id", Id);
			var address = conn.QueryFirstOrDefault<Models.Address>(sqlcmd, param);
			return address;

		}
		public bool DeleteAddress(Models.Address value)
		{
			try
			{
				if (value.Id != 0)
				{
					value.DeletedTime = DateTime.Now;
					return CreatingOrUpdatingAddress(value);
				}
				else
				{
					return false;
				}
			}
			catch (SystemException ex)
			{
				Console.WriteLine(string.Format("An error occurred: {0}", ex.ToString()));
				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		public bool Create(Models.Address value)
		{
			try
			{
				if (value != null)
				{
					value.Id = -1;
					value.DeletedTime = null;
					return CreatingOrUpdatingAddress(value);
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		public bool Update(Models.Address value)
		{
			try
			{
				value.DeletedTime = null;
				return CreatingOrUpdatingAddress(value);
			}
			catch (Exception ex)
			{

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		public bool CreatingOrUpdatingAddress(Models.Address value)
		{
			var conn = _dbContext.GetConnection();
			var param = new DynamicParameters();
			param.Add("@Country", value.Country);
			param.Add("@City", value.City);
			param.Add("@Zip", value.Zip);
			param.Add("@Street", value.Street);
			param.Add("@Id", value.Id);
			param.Add("@Delete", value.DeletedTime);
			param.Add("@CompanyId", value.compId);
			param.Add("@EmployeeId", value.empId);
			return conn.Execute("dbo.spCreateOrUpdateAddress", param, commandType: CommandType.StoredProcedure) > 0;
		}
	}
}