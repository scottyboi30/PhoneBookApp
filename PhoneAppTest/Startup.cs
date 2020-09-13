using System.Collections.Generic;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneAppTest.Data;
using PhoneAppTest.Extensions;
using PhoneAppTest.Models;
using PhoneAppTest.Services;
using PhoneAppTest.Validators;

namespace PhoneAppTest
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
            services.AddMvc().AddFluentValidation(fv => {
                //fv.ImplicitlyValidateChildProperties = true;
            });

            services.AddDbContext<ContactsContext>(options => options.UseInMemoryDatabase(databaseName: "Contacts"));
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.AddScoped<IContactsRepository, ContactsRepository>();
            services.AddScoped<IContactsService, ContactsService>();
            services.AddTransient<IValidator<List<Contact>>, ContactEnumerableValidator>();
            services.AddTransient<IValidator<Contact>, ContactValidator>();
            services.AddSwaggerDocumentation();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseSwaggerDocumention();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
