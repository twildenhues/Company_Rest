using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace CompanyAPI.Repository
{
	class CompanyRepository : IDisposable
	{
		private SqlConnection conn = new SqlConnection();
		public CompanyRepository()
		{
			conn.ConnectionString = "Data Source=tappqa;Initial Catalog=Training-TW-Company;Integrated Security=True";
			conn.Open();
		}
		public List<Models.Company> ReadCompany()
		{
			string sqlcmd = "SELECT Id, Name, CreatedTime, Country, City, Zip, Street, DepartementName, ManagerId FROM viCompany";
			var test = conn.Query<Models.Company>(sqlcmd).ToList();
			return test;
		}
		public Models.Company Read(int Id)
		{
			string sqlcmd = "SELECT Id, Name, CreatedTime, Country, City, Zip, Street, DepartementName, ManagerId FROM viCompany where Id = @Id";
			var param = new DynamicParameters();
			param.Add("@Id", Id);
			var company = conn.QueryFirstOrDefault<Models.Company>(sqlcmd, param);
			return company;

		}
		public bool DeleteCompany(int CompanyId)
		{
			try
			{
					var param = new DynamicParameters();
					param.Add("@Name", null);
					param.Add("@Id", CompanyId);
					param.Add("@Delete", DateTime.Now);
					return conn.Execute("dbo.spCreateOrUpdateCompany", param, commandType: CommandType.StoredProcedure) > 0;
			}
			catch (SystemException ex)
			{
				Console.WriteLine(string.Format("An error occurred: {0}", ex.ToString()));
				return false;
			}
		}
		public bool CreatingOrUpdatingCompany(int CompanyId, string value)
		{

			using (SqlCommand insertCommand = new SqlCommand("dbo.spCreateOrUpdateCompany", conn))
			{
				var param = new DynamicParameters();
				param.Add("@Name", value);
				param.Add("@Id", CompanyId);
				param.Add("@Delete", null);
				return conn.Execute("dbo.spCreateOrUpdateCompany", param, commandType: CommandType.StoredProcedure) > 0;
			}
		}

		public void Dispose()
		{
			conn.Close();
		}
	}
}