using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Shiftwise._52cards.mvc.App.App_Start.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Shiftwise._52cards.mvc.App.App_Start.UnityWebActivator), "Shutdown")]

namespace Shiftwise._52cards.mvc.App.App_Start
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

#if NoMEF
				DependencyResolver.SetResolver(new UnityDependencyResolver(container));
#else
            //Component initialization via MEF
            //jims: no export[ ] in app so not needed, forwebapi
            //Resolver.Resolver.ComponentLoader.LoadContainer(container, ".\\bin", "Logqsp.dll");
            Shiftwise._52cards.mvc.resolver.mef.ComponentLoader.LoadContainer(container, ".\\bin", "Shiftwise._52cards.mvc.domain.dll");
            Shiftwise._52cards.mvc.resolver.mef.ComponentLoader.LoadContainer(container, ".\\bin", "Shiftwise._52cards.mvc.repository.dll");
            //jims: MVC resolver
            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            //jims: Webapi resolver
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


#endif
            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}