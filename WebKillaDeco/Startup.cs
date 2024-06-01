using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            try
            {
                _dbInMemory = Configuration.GetValue<bool>("DbInMem");
            }
            catch
            {
                _dbInMemory = true;
            }
        }

        public IConfiguration Configuration { get; }
        public bool _dbInMemory = false;

        // Este método es llamado por el runtime. Usa este método para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Tipo de DB provider a usar
            if (_dbInMemory)
            {
                services.AddDbContext<KillaDbContext>(options => options.UseInMemoryDatabase("KillaDB"));
            }
            else
            {
                services.AddDbContext<KillaDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("KillaCS"))
                );
            }
            #endregion

            services.AddScoped<DataPreload>();

            #region Identity
            services.AddIdentity<User, Rol>()
                .AddEntityFrameworkStores<KillaDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager<SignInManager<User>>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                // Agrega otras configuraciones necesarias para Identity aquí.
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; // Ruta de inicio de sesión
                options.LogoutPath = "/Identity/Account/Logout"; // Ruta de cierre de sesión
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            });
            #endregion

            services.AddControllersWithViews();

            // Agregar servicios de páginas de Razor
            services.AddRazorPages();
        }

        // Este método es llamado por el runtime. Configura el pipeline de HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, KillaDbContext killaDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var contexto = serviceScope.ServiceProvider.GetRequiredService<KillaDbContext>();

                if (!_dbInMemory)
                {
                    killaDbContext.Database.Migrate();
                }
                serviceScope.ServiceProvider.GetService<DataPreload>().LoadData();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
