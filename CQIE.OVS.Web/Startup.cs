using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQIE.OVS.DataAccess.Database;
using CQIE.OVS.Services.IService;
using CQIE.OVS.Services.Service;
using CQIE.OVS.Models;
using CQIE.OVS.Repository.IRepository;
using CQIE.OVS.Repository.Repository;
using CQIE.OVS.Models.IdentityModel;
using CQIE.OVS.Web.Models;
using Microsoft.AspNetCore.Identity;
using CQIE.OVS.Services;
using CQIE.OVS.Web.MiddleWare;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace CQIE.OVS.Web
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
            //���ȫ�ֵ���ȨAuthorize����
            //services.AddMvc(config => {
            //    var policy = new AuthorizationPolicyBuilder()
            //                    .RequireAuthenticatedUser()
            //                    .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
            //ע��OVSDBContext���ݿ�������
            services.AddDbContext<OVSDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("OVSDefaultDb"));
            });

            //ע����ط���
            services.RegisterServices();
            //ע��Identity
            services.AddIdentity<SysUser, SysRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddErrorDescriber<CustomIdentityErrorDescriber>() //ģ����֤���������
                    .AddEntityFrameworkStores<OVSDbContext>();

            // ע���Զ����Session����
            services.AddDistributedMemoryCache();
            services.AddSession(config =>
            {
                config.Cookie.IsEssential = true;
                config.Cookie.Name = "UserSession";
                config.Cookie.HttpOnly = true;
                config.IdleTimeout = TimeSpan.FromHours(15);
            });
            services.AddScoped(typeof(SessionService));

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(15);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();//��Ȩ
            app.UseAuthorization();//��Ȩ

            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "areas",//Ҫ����default֮ǰ
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public static class IocExtend
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IThemeRepository, ThemeRepository>();
            services.AddScoped<IThemeService, ThemeServiceImp>();
            services.AddScoped<ISingerRepository, SingerRepository>();
            services.AddScoped<ISingerService, SingerServiceImp>();

            services.AddScoped<IBaseRepository<Singer>, BaseRepository<Singer>>();
            services.AddScoped<IBaseService<Singer>, BaseServiceImp<Singer>>();
            services.AddScoped<IBaseRepository<Theme>, BaseRepository<Theme>>();
            services.AddScoped<IBaseService<Theme>, BaseServiceImp<Theme>>();

            //��ע����ǳ�����ʱ��ʹ��typeofת��
            //services.AddScoped(typeof(IBaseRepository<Singer>), typeof(BaseRepository<Singer>));
            //services.AddScoped(typeof(IBaseService<Singer>), typeof(BaseServiceImp<Singer>));
            //services.AddScoped(typeof(IBaseRepository<Theme>), typeof(BaseRepository<Theme>));
            //services.AddScoped(typeof(IBaseService<Theme>), typeof(BaseServiceImp<Theme>));
        }
    }
}
