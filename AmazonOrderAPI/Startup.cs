using AmazonOrderAPI.AutoMapperConfig;
using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.Business.Repositories.ServicesImp;
using AmazonOrderAPI.Configuration;
using AmazonOrderAPI.Filters;
using IdentityModel;
using LoggerService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NLog.Layouts;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace AmazonOrderAPI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            var connectionString = Configuration.GetConnectionString("dbConnection");
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // services.AddIdentity<IdentityUser, IdentityRole>();
            services.AddAuthentication(options =>
            {
                // Notice the schema name is case sensitive [ cookies != Cookies ]
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")//, options => options.ForwardDefaultSelector = ctx => ctx.Request.Path.StartsWithSegments("/api1") ? "jwt" : "Cookies")
            .AddJwtBearer("jwt", options =>
            {
                options.Authority = "http://identity.softpal.com";
                //options.Authority = "https://localhost:44397/";
                options.Audience = "api1";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,
                };

                //options.Scope.Clear();
                //options.Scope.Add(AuthenticationConsts.ScopeOpenId);
                //options.Scope.Add(AuthenticationConsts.ScopeProfile);
                //options.Scope.Add(AuthenticationConsts.ScopeEmail);
                //options.Scope.Add(AuthenticationConsts.ScopeRoles);
                //options.Scope.Add("api1");
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                //options.Authority = "https://localhost:44397/";
                options.Authority = "http://identity.softpal.com/";
                options.RequireHttpsMetadata = false;
                options.ClientId = "AmzBombax";
                options.SaveTokens = true;

                options.ClientSecret = "Test";
                //options.ResponseType = "code id_token";
                options.ResponseType = "id_token";
                options.GetClaimsFromUserInfoEndpoint = true;

                //options.Scope.Add("roles");

                options.Scope.Clear();
                options.Scope.Add(AuthenticationConsts.ScopeOpenId);
                options.Scope.Add(AuthenticationConsts.ScopeProfile);
                options.Scope.Add(AuthenticationConsts.ScopeEmail);
                options.Scope.Add(AuthenticationConsts.ScopeRoles);
                options.Scope.Add("SellerId");

                //options.Scope.Add("api1");
                options.Scope.Add("offline_access");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,
                };

                //   options.ForwardDefaultSelector = ctx => ctx.Request.Path.StartsWithSegments("/api1") ? "jwt" : "oidc";
            });

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<AmazonOrderAPI.DataContext.OrderContext>(options =>
                     options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AmazonOrderAPI"))

                     //.options.UseSqlServer(connectionString, b => b.UseRowNumberForPaging())

                  //options.UseSqlServer(connectionString,b =>  b.MigrationsAssembly("AmazonOrderAPI"), b.UseRowNumberForPaging() })
                  .UseLazyLoadingProxies());

            Layout.Register("Encrypt", typeof(EncryptLayoutRendererWrapper));

            services.AddTransient<IOrderFetchServices, OrderFetchServices>();
            services.AddTransient<IDashboardService, DashboardServices>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddTransient<IAmazonServices, AmazonServices>();
            services.AddTransient<ISellerServices, SellerServices>();

            services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));
            AddMvcLocalization(services);

            AddAuthorizationPolicies(services);

            //services.AddIdentityServer(x => x.Discovery.CustomEntries.Add("Users_endpoint", "~/api/User/ClientUsers"))

            //   // .AddAspNetIdentity<IdentityUser>()

            //   .AddInMemoryClients(Clients.Get())
            //   .AddInMemoryIdentityResources(Resources.GetIdentityResources())
            //   .AddInMemoryApiResources(Resources.GetApiResources());
            //    .AddTestUsers(Users.Get())

            // .AddDeveloperSigningCredential();

            AutoMapperConfiguration.Configure();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
         //   app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=DashBoard}/{action=Index}");
            });
            //app.UseMvc();
        }

        public void AddAuthorizationPolicies(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                    policy => policy.RequireRole(AuthorizationConsts.AdministrationRole));

                options.AddPolicy(AuthorizationConsts.AdminPolicy,
                    policy => policy.RequireRole(AuthorizationConsts.AdminRole));

                options.AddPolicy(AuthorizationConsts.CourierUserPolicy,
                   policy => policy.RequireRole(AuthorizationConsts.CourierRole));

                options.AddPolicy(AuthorizationConsts.SellerUserPolicy,
                  policy => policy.RequireRole(AuthorizationConsts.SellerRole));

                options.AddPolicy(AuthorizationConsts.SellerUserPolicy, policy => policy.RequireClaim(AuthorizationConsts.SellerRole, AuthorizationConsts.AdminRole));

                //    options.AddPolicy("AdminSeller", policy =>
                // policy.RequireAssertion(context =>
                //context.User.HasClaim(c =>
                //    (c.Type == AuthorizationConsts.SellerRole ||
                //     c.Type == AuthorizationConsts.AdminRole))));// &&
                //                                                 //c.Issuer == "https://microsoftsecurity")));
            });
        }

        public void AddMvcLocalization(IServiceCollection services)
        {
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

            services.AddLocalization(opts => { opts.ResourcesPath = Constants.ResourcesPath; });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddViewLocalization(
                    LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = Constants.ResourcesPath; })
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supportedCultures = new[]
                    {
                        new CultureInfo("zh-CN"),
                        new CultureInfo("en-US"),
                        new CultureInfo("en")
                    };

                    opts.DefaultRequestCulture = new RequestCulture("en");
                    opts.SupportedCultures = supportedCultures;
                    opts.SupportedUICultures = supportedCultures;
                });
        }
    }
}