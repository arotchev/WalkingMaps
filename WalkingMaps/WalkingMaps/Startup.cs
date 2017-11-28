using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WalkingMaps.Entities;
using WalkingMaps.Infrastructure;
using WalkingMaps.Infrastructure.Repositories.Abstract;
using WalkingMaps.Infrastructure.Repositories.Concrete;
using System.Security.Claims;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Routing;
using WalkingMaps.Infrastructure.Mappings;
using WalkingMaps.Services.Abstract;
using WalkingMaps.Services.ExportWalk;

namespace WalkingMaps
{
    public class Startup
    {
        private static string _contentRootPath;
        private string _applicationPath;

        public Startup(IHostingEnvironment env)
        {
            _contentRootPath = env.ContentRootPath;
            _applicationPath = env.WebRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                    .AddDbContext<WalkingMapsDBContext>(
                options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<WalkingMapsDBContext>();

            // Repositories
            //services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IWalkRepository, WalkRepository>();
            services.AddScoped<IWalkSightRepository, WalkSightRepository>();
            services.AddScoped<ISightRepository, SightRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<ILoggingRepository, LoggingRepository>();
            services.AddScoped<IExportWalk, ExportWalk>();


            // Polices
            services.AddAuthorization(options =>
            {
                // inline policies for easier control over exec of controller methods
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Administrator");
                });

            });

            // Add MVC services to the services container.
            services.AddMvc()
            .AddJsonOptions(opt =>
            {
                //to maintain C# property names in the JSON.
                var resolver = opt.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    var res = resolver as DefaultContractResolver;
                    res.NamingStrategy = null;
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // this will serve up wwwroot
            app.UseFileServer();

            //custom extension to access js files for SPA
            app.UseNodeModules(env);


            app.UseIdentity();

            AutoMapperConfiguration.Configure();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            
            // Add MVC to the request pipeline.
            app.UseMvc(ConfigureRoutes);           

            DbInitializer.Initialize(app.ApplicationServices, _applicationPath);
            //CreateKML.Create(app.ApplicationServices);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            //routeBuilder.MapRoute("Default",                "{controller=Home}/{action=Index}/{id?}");

            routeBuilder.MapRoute("Default",
                "{controller=Admin}/{action=Index}/{id?}");
        }
    }
}
