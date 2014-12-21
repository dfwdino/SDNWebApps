using System.Web.Mvc;

namespace SDNWebApps.Areas.GroceryList
{
    public class GroceryListAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GroceryList";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GroceryList_default",
                "GroceryList/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
