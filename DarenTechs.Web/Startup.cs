using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using React.AspNet;
using DarenTechs.Web.Services;
using DarenTechs.Data.Data;
using DarenTechs.Data.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Mvc.Razor;
using DarenTechs.UI.Components.Modal;
using DarenTechs.Data.Interfaces;

namespace DarenTechs.Web
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
            services.AddReact();

            services.AddDbContext<DarenTechsIdentityContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DarenTechsConnection"),
                x => x.MigrationsAssembly("DarenTechs.Data")));

            services.AddDbContext<DarenTechsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DarenTechsConnection"),
                x => x.MigrationsAssembly("DarenTechs.Data")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DarenTechsIdentityContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IBlogService, BlogService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(Repository<>));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddMvc();

            var assemblyBlog = typeof(DarenTechs.Blog.ViewComponents.BlogNavigationViewComponent).GetTypeInfo().Assembly;
            services.AddMvc().AddApplicationPart(assemblyBlog);

            var uiProvider = new EmbeddedFileProvider(assemblyBlog, "DarenTechs.Blog");

            //Add the file provider to the Razor view engine
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(uiProvider);
            });

            services.AddMvc(config => config.ModelBinderProviders.Insert(0, new BootstrapModalBinderProvider()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseReact(config =>
            {
                config.SetLoadBabel(false).AddScriptWithoutTransform("~/js/bundle.js");
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
