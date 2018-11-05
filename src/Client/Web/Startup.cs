using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using Unity;
using Unity.Injection;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.PolicyInjection.Pipeline;

namespace NetCore21Angular.Client.Web
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
            services.AddDbContext<Database.NetCore21AngularDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            Configure_CompositionRoot(services);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        private void Configure_CompositionRoot(IServiceCollection services)
        {
            // Manager
            services.AddTransient<Manager.Configuration.Chemistry.Contract.IPeriodicElementManager, Manager.Configuration.Chemistry.PeriodicElementManager>();

            // Engine
            services.AddTransient<Engine.Validation.Contract.IPeriodicElementValidationEngine, Engine.Validation.PeriodicElementValidationEngine>();

            // Resource
            services.AddTransient<Resource.Configuration.Chemistry.Contract.IPeriodicElementResource, Resource.Configuration.Chemistry.PeriodicElementResource>();
        }

        private void Configure_CompositionRoot_Test(IServiceCollection services)
        {
            UnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();

            // Database
            container.RegisterType<Database.NetCore21AngularDbContext>(new InjectionFactory((x) => services.BuildServiceProvider().GetService<Database.NetCore21AngularDbContext>()));

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
