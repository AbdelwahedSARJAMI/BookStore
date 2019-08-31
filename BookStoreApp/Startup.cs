using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;
using BookStoreApp.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreApp
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();//activation de la dependance MVC
            //services.AddSingleton<IRepo<Author>, AuthorRepository>();//creation d'une seul instance dans notre projet
            services.AddScoped<IRepo<Author>, DBAuthorRepository>();

            services.AddDbContext<BookStoreDBContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/

            //app.UseMvc();//enable middleware MVC

            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Author}/{action=Index}/{id?}");
            });//pour definir le controlleur & l'action par default

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();//application de la modalite /controller/action sur notre projet

        }
    }
}
