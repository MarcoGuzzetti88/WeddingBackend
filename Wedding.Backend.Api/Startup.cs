using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Wedding.Backend.BLL;
using Wedding.Backend.BLL.Generic;
using Wedding.Backend.DAL.Models;
using Wedding.Backend.DAL.Repository;

namespace Wedding.Backend.Api
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
            services.AddControllers();
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddDbContext<Context>(options => options
                .UseMySql("server=192.168.0.254;port=3306;user=marco;password=mg1988;database=wedding",
                    mysqlOptions =>
                        mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 13), ServerType.MariaDb))));

            services.AddHttpContextAccessor();

            services.AddScoped<IContributionHandler, ContributionHandler>();
            services.AddScoped<IContributorHandler, ContributorHandler>();
            services.AddScoped<IEmailSender, GmailSmtpSender>();
            services.AddScoped<IPackageRetreiver, PackageRetreiver>();
            services.AddScoped<IWeddingMailHandler, WeddingMailHandler>();
            services.AddScoped<IReadAll<Domain.Contribution>, ContributionRepository>();
            services.AddScoped<IWrite<Domain.Contribution>, ContributionRepository>();
            services.AddScoped<IRead<Domain.Contributor, string>, ContributorRepository>();
            services.AddScoped<IWrite<Domain.Contributor>, ContributorRepository>();
            services.AddScoped<IReadAll<Domain.Package>, PackageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}