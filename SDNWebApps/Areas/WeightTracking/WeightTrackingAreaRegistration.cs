using System.Web.Mvc;

namespace SDNWebApps.Areas.WeightTracking
{
    public class WeightTrackingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WeightTracking";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WeightTracking_default",
                "WeightTracking/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}