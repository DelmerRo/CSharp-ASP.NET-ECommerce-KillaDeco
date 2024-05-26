using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Data;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Tipo de DB provider a usar
            if (_dbInMemory)
            {
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("KillaDB"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ForoCS"))
                );
            }
            #endregion

            services.AddScoped<PrecargaDatos>();

            #region Identity
            services.AddIdentity<Usuario, Rol>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(
                opciones =>
                {
                    opciones.Password.RequiredLength = 8;
                }
                );
            #endregion

            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opciones =>
                {
                    opciones.LoginPath = "/Account/IniciarSesion";
                    opciones.AccessDeniedPath = "/Account/AccesoDenegado";
                });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext applicationDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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
                var contexto = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!_dbInMemory)
                {
                    applicationDbContext.Database.Migrate();

                }
                serviceScope.ServiceProvider.GetService<PrecargaDatos>().TraerInformacionDeData();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            }
        );
        }
    }
}