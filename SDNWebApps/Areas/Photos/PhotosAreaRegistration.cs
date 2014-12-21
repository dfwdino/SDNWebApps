using System.Web.Mvc;

namespace SDNWebApps.Areas.Photos
{
    public class PhotoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Photos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Photos_default",
                "Photos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
