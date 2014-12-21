using System.Web.Mvc;

namespace SDNWebApps.Areas.Baby
{
    public class BabyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Baby";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Baby_default",
                "Baby/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
          
        }
    }
}
