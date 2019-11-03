using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Unity;
using Unity.Injection;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace NetCoreAngular.Client.Web
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration.GetValue<string>("Authentication:Issuer"),
                            ValidAudience = Configuration.GetValue<string>("Authentication:Issuer"),
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Authentication:Secret"))),
                            ClockSkew = TimeSpan.Zero
                        };
                });

            services.AddDbContext<Database.NetCoreAngularDbContext>(options =>
            {
                if (Configuration.GetValue("UseMySql", false))
                {
                    options.UseMySql(Configuration.GetConnectionString("MySqlDefaultConnection"));
                }
                else
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                }
            });

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                //configuration.RootPath = "ClientApp/dist";

                configuration.RootPath = "wwwroot/dist";
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<Database.NetCoreAngularDbContext>();

            Configure_CompositionRoot(services);
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
                UpdateDatabase(app);

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "wwwroot";
            });
        }


        private void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (Database.NetCoreAngularDbContext netCore21AngularDbContext = serviceScope.ServiceProvider.GetService<Database.NetCoreAngularDbContext>())
                {
                    netCore21AngularDbContext.Database.Migrate();
                }
            }
        }

        private void Configure_CompositionRoot(IServiceCollection services)
        {
            // Manager
            services.AddTransient<Manager.Configuration.Chemistry.Contract.IPeriodicElementManager, Manager.Configuration.Chemistry.PeriodicElementManager>();
            services.AddTransient<Manager.Configuration.IPeopleManager, Manager.Configuration.PeopleManager>();

            // Engine
            services.AddTransient<Engine.Validation.Configuration.Contract.IPeriodicElementValidationEngine, Engine.Validation.Configuration.PeriodicElementValidationEngine>();

            // Resource
            services.AddTransient<Resource.Configuration.Chemistry.Contract.IPeriodicElementResource, Resource.Configuration.Chemistry.PeriodicElementResource>();
            services.AddTransient<Resource.Configuration.IPeopleResource, Resource.Configuration.PeopleResource>();
        }

        private void Configure_CompositionRoot_Test(IServiceCollection services)
        {
            UnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();

            // Database
            container.RegisterType<Database.NetCoreAngularDbContext>(new InjectionFactory((x) => services.BuildServiceProvider().GetService<Database.NetCoreAngularDbContext>()));

            // Resource
            container.RegisterType<Resource.Configuration.Chemistry.Contract.IPeriodicElementResource, Resource.Configuration.Chemistry.PeriodicElementResource>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<TransactionInterceptionBehavior>());
            services.AddTransient((x) => container.Resolve<Resource.Configuration.Chemistry.Contract.IPeriodicElementResource>());

            // Engine


            // Manager
            container.RegisterType<Manager.Configuration.Chemistry.Contract.IPeriodicElementManager, Manager.Configuration.Chemistry.PeriodicElementManager>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<TransactionInterceptionBehavior>());
            services.AddTransient((x) => container.Resolve<Manager.Configuration.Chemistry.Contract.IPeriodicElementManager>());
        }

        private class TransactionInterceptionBehavior : IInterceptionBehavior
        {
            public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
            {
                MethodInfo methodInfo = input.MethodBase as MethodInfo;

                TransactionFlowAttribute transactionFlowAttribute = methodInfo.GetCustomAttribute<TransactionFlowAttribute>();

                var result = getNext()(input, getNext);

                return result;
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            public bool WillExecute { get { return true; } }
        }


        public class TransactionFlowAttribute : Attribute
        {
            public TransactionFlowOption TransactionFlowOption { get; }

            public TransactionFlowAttribute(TransactionFlowOption transactionFlowOption)
            {
                TransactionFlowOption = transactionFlowOption;
            }
        }

        public enum TransactionFlowOption
        {
            Mandatory,
            Allowed,
            NotAllowed
        }
    }
}
