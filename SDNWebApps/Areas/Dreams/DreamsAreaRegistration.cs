using System.Web.Mvc;

namespace SDNWebApps.Areas.Dreams
{
    public class DreamsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dreams";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dreams_default",
                "Dreams/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Dreams_miles",
                "Dreams/{controller}/{action}/{id}/",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
