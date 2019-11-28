using System.Web.Mvc;

namespace SDNWebApps.Areas.Relationship
{
    public class RelationshipAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Relationship";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Relationship_default",
                "Relationship/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}