using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace CompanyAPI.Repository
{
	class AddressRepository : IDisposable
	{
		private SqlConnection conn = new SqlConnection();
		public AddressRepository()
		{
			conn.ConnectionString = "Data Source=tappqa;Initial Catalog=Training-TW-Company;Integrated Security=True";
			conn.Open();
		}
		public List<Models.Address> ReadAddress()
		{
			string sqlcmd = "SELECT Id, Country, City, Zip, Street, CreatedTime FROM viAddress";
			var test = conn.Query<Models.Address>(sqlcmd).ToList();
			return test;
		}
		public Models.Address Read(int Id)
		{
			string sqlcmd = "SELECT Id, Country, City, Zip, Street, CreatedTime FROM viAddress FROM viAddress where Id = @Id";
			var param = new DynamicParameters();
			param.Add("@Id", Id);
			var address = conn.QueryFirstOrDefault<Models.Address>(sqlcmd, param);
			return address;

		}
		public bool DeleteAddress(int AddressId)
		{
			try
			{
				var param = new DynamicParameters();
				param.Add("@Id", AddressId);
				param.Add("@Delete", DateTime.Now);
				return conn.Execute("dbo.spCreateOrUpdateAddress", param, commandType: CommandType.StoredProcedure) > 0;
			}
			catch (SystemException ex)
			{
				Console.WriteLine(string.Format("An error occurred: {0}", ex.ToString()));
				return false;
			}
		}
		public bool CreatingOrUpdatingAddress(int CompanyId, string value, int compId, int empId)
		{
			var param = new DynamicParameters();
			param.Add("@Country", value);
			param.Add("@City", CompanyId);
			param.Add("@Zip", value);
			param.Add("@Street", value);
			param.Add("@Id", CompanyId);
			param.Add("@Delete", null);
			param.Add("@CompanyId", compId);
			param.Add("@EmployeeId", empId);
			return conn.Execute("dbo.spCreateOrUpdateAddress", param, commandType: CommandType.StoredProcedure) > 0;
		}
		public void Dispose()
		{
			conn.Close();
		}
	}
}