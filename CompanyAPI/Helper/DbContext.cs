using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CompanyAPI.Interfaces;
using CompanyAPI.Models;
using Microsoft.Extensions.Options;

namespace CompanyAPI.Helper
{
	public class DbContext : IDbContext
	{
		private readonly DbSettings _settings;
		public DbContext(IOptions<DbSettings> options) {
			_settings = options.Value;
		}
		public IDbConnection GetConnection() {
			var conn = new SqlConnection(_settings.Company);
			conn.Open();
			return conn;
		}
	}
}
