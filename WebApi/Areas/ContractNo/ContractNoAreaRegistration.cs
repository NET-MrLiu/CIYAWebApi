using System.Web.Mvc;

namespace WebApi.Areas.ContractNo
{
    public class ContractNoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ContractNo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ContractNo_default",
                "ContractNo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}