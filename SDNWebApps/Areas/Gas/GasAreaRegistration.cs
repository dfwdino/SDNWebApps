using System.Web.Mvc;

namespace SDNWebApps.Areas.Gas
{
    public class GasAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Gas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Gas_default",
                "Gas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Gas_miles",
                "Gas/{controller}/{action}/{id}/",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
