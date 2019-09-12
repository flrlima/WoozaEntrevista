using System.Web.Http;
using Wooza.Entrevista.Service.AutoMapper;

namespace Wooza.Entrevista.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
