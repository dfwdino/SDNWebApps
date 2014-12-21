using System.Web.Mvc;

namespace SDNWebApps.Areas.Tasks
{
    public class TasksAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Tasks";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Tasks_default",
                "Tasks/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
