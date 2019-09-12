using System.Web.Mvc;

namespace WebApi.Areas.SignIn
{
    public class SignInAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SignIn";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SignIn_default",
                "SignIn/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}