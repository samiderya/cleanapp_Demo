using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.Formatters;
using Server.Contexts;
using Server.Services;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //     services.AddMvc(options =>
            //   {
            //       // Return a 406 when an unsupported media type was requested
            //      // options.ReturnHttpNotAcceptable = true;

            //       // Add XML formatters
            //       options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            //       //options.InputFormatters.Add(new XmlSerializerInputFormatter());

            //       // Set XML as default format instead of JSON - the first formatter in the 
            //       // list is the default, so we insert the input/output formatters at 
            //       // position 0
            //       //options.InputFormatters.Insert(0, new XmlSerializerInputFormatter(options));
            //   }
            //   );
            services.AddMvc(options =>
    {
        options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
        var jsonInputFormatter = options.InputFormatters.OfType<JsonInputFormatter>().First();
        jsonInputFormatter.SupportedMediaTypes.Add("multipart/form-data");
    });

            // add support for compressing responses (eg gzip)
            // services.AddResponseCompression();
            services.AddOptions();
            // services.AddMvcCore()
            //  .AddApiExplorer();
            services.AddCors(options =>
           {

               options.AddPolicy("AllowAllOrigins",
                   builder =>
                   {
                       builder
                                  //.WithOrigins("https://localhost:44342");
                                  .AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                   });
           });
            // Add framework services.
            services.AddDbContext<CleanerDBContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICleaningRepository, CleaningRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IGeneralRepository, GeneralRepository>();
            services.AddScoped<IBackgroundRepository, BackgroundRepository>();




            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Executive Handy API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //  app.UseCors("AllowAll");
            // global cors policy
            app.UseHttpMethodOverride();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MCP API V1");
            });
            app.UseMvc();

        }

    }
}
