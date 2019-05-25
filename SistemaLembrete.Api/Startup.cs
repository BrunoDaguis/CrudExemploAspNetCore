using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaLembrete.Api.Filters;
using SistemaLembrete.Application;
using SistemaLembrete.Application.Applications;
using SistemaLembrete.Application.Applications.Base;
using SistemaLembrete.Application.Interfaces;
using SistemaLembrete.Application.Interfaces.Base;
using SistemaLembrete.Core.Notifications;
using SistemaLembrete.Domain.Interfaces;
using SistemaLembrete.Repository.Context;
using SistemaLembrete.Repository.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace SistemaLembrete.Api
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
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AzureBd001Connection")));

            
            services.AddMvc(options => options.Filters.Add<NotificationFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opcoes => // Remove valores nulos das respostas
            {
                opcoes.SerializerSettings.NullValueHandling =
                    Newtonsoft.Json.NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Api Sistema Lembrete", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddTransient(typeof(IUsuarioApplication), typeof(UsuarioApplication));

            services.AddTransient(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped<NotificationContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Sistema Lembrete V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();
            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
