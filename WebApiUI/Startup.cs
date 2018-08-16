using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;

[assembly: OwinStartup(typeof(WebApiUI.Startup))]

namespace WebApiUI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan=TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
            app.UseOAuthAuthorizationServer(option);
            
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
           
        }
    }
}
