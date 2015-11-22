using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;
using Ninject;
using System;
using Web.App_Start;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var httpConfig = new HttpConfiguration();

            WebApiConfig.Register(httpConfig);

            httpConfig.EnsureInitialized();

            app
                   .UseNinjectMiddleware(NinjectConfig.CreateKernel)
                   .UseNinjectWebApi(httpConfig);
        }

    }
}
