using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using CompanyAPI.Interfaces;

namespace CompanyAPI.Repository
{
	class CompanyRepository : ICompanyRepository
	{
		IDbContext _dbContext;
		public CompanyRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public List<Models.Company> ReadAll()
		{
			try
			{
				var conn = _dbContext.GetConnection(); 
				string sqlcmd = "SELECT " +
									"Id, " +
									"Name, " +
									"CreatedTime, " +
									"Country, " +
									"City, " +
									"Zip, " +
									"Street, " +
									"DepartementName, " +
									"ManagerId " +
								"FROM viCompany";
				var resval = conn.Query<Models.Company>(sqlcmd).ToList();
				return resval;
			}
			catch (SqlException ex)
			{
				// logging ex

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.SQLERROR);
			}
		}
		public Models.Company Read(int Id)
		{
			try
			{
				var conn = _dbContext.GetConnection(); 
				string sqlcmd = "SELECT " +
									"Id, " +
									"Name, " +
									"CreatedTime, " +
									"Country, " +
									"City, " +
									"Zip, " +
									"Street, " +
									"DepartementName, " +
									"ManasgerId " +
								"FROM viCompany " +
								"WHERE Id = @Id";
				var param = new DynamicParameters();
				param.Add("@Id", Id);
				var resval = conn.QueryFirstOrDefault<Models.Company>(sqlcmd, param);
				return resval;
			}
			catch (SqlException ex)
			{
				// logging ex

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.SQLERROR);
			}
		}
		public bool DeleteCompany(Models.Company value)
		{
			try
			{
				if (value.Id != 0)
				{
					Models.Company temp = new Models.Company
					{
						Id = value.Id,
						DeletedTime = DateTime.Now
					};
					var resval = CreatingOrUpdatingCompany(temp);
					return resval;
				}
				else {
					throw new Helper.RepositoryException(UpdateResultType.INVALIDEARGUMENT);
				}
			}
			catch (SystemException ex)
			{
				Console.WriteLine(string.Format("An error occurred: {0}", ex.ToString()));
				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		public bool Create(Models.Company value)
		{
			try
			{
				if (value.Name != null)
				{
					Models.Company temp = new Models.Company {
						Id = -1,
						DeletedTime = value.DeletedTime = null,
						Name = value.Name
					};
					
					var resval = CreatingOrUpdatingCompany(value);
					return resval;
				}
				else {
					throw new Helper.RepositoryException(UpdateResultType.INVALIDEARGUMENT);
				}
			}
			catch (Exception ex)
			{

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		public bool Update(Models.Company value)
		{
			try
			{
				if (value.Id != 0)
				{
					value.DeletedTime = null;
					var resval = CreatingOrUpdatingCompany(value);
					return resval;
				}
				else
				{
					throw new Helper.RepositoryException(UpdateResultType.INVALIDEARGUMENT);
				}
			}
			catch (Exception ex)
			{

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			}
		}
		private bool CreatingOrUpdatingCompany(Models.Company value)
		{
			try
			{
				var conn = _dbContext.GetConnection();
				var param = new DynamicParameters();
				param.Add("@Name", value.Name);
				param.Add("@Id", value.Id);
				param.Add("@Delete", value.DeletedTime);
				var resval = conn.Execute("dbo.spCreateOrUpdateCompany", param, commandType: CommandType.StoredProcedure) > 0;
				return resval;
			}
			catch (Exception ex)
			{

				throw new Helper.RepositoryException(ex.Message, UpdateResultType.ERROR);
			};
		}
	}
}