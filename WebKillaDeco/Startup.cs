using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebKillaDeco.Data;
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

        // This method gets called by the runtime. Use this method to add services to the container.
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
            services.AddIdentity<User, Rol>().AddEntityFrameworkStores<KillaDbContext>();

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
       public void Configure(IApplicationBuilder app, IWebHostEnvironment env, KillaDbContext killaDbContext)
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

    var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();

    if (serviceScopeFactory != null)
    {
        using (var serviceScope = serviceScopeFactory.CreateScope())
        {
            var contexto = serviceScope.ServiceProvider.GetRequiredService<KillaDbContext>();

            if (!_dbInMemory)
            {
                killaDbContext?.Database.Migrate();
            }
            serviceScope.ServiceProvider.GetService<DataPreload>()?.LoadDataAsync();
        }
    }

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
    }
}
