using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using _2_Common;
using _2_Common.Extensions;
using _3_Persistency.Implementations;

namespace MTE.Api
{
    public class Startup
    {
        private string CorsConfigName => "MTE";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy(this.CorsConfigName, cors =>
            {
                cors.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddMvc();
            services.AddSingleton(Configuration);

            services.AddDatabase(Configuration.GetConnectionString("MTEDBConnectionString"));
            var builder = new ContainerBuilder();
            builder.RegisterModule<CqrsAutofacModule>();

            builder.Populate(services);
            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            MTEContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(this.CorsConfigName);
            app.UseMvc();
        }
    }
}
