using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CompanyAPI.Interfaces;
using CompanyAPI.Repository;
using CompanyAPI.Models;
using CompanyAPI.Helper;
using TobitLogger.Core;
using TobitLogger.Logstash;
using TobitLogger.Middleware;
using TobitWebApiExtensions.Extensions;
using Microsoft.AspNetCore.Http;

namespace CompanyAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<ILogContextProvider, RequestGuidContextProvider>();

			services.AddChaynsToken();
			services.AddMvc();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));

			services.AddSingleton<IDbContext, DbContext>();

			services.AddScoped<ICompanyRepository, CompanyRepository>();
			services.AddScoped<IAddressRepository, AddressRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ILogContextProvider logContextProvider)
		{
			loggerFactory.AddLogstashLogger(Configuration.GetSection("Logger"), logContextProvider: logContextProvider);


			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseRequestLogging();
			// app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
