using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SDNWebApps.Infrastructure
{
    public class AccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var url = HttpContext.Current.Request.Url.ToString();

            HttpCookie cookie = HttpContext.Current.Request.Cookies["SDNWebApps"];

            if ((cookie == null))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login",
                    area = "Login"
                }));
            }

        }

        public static HttpRequest GetHttpRequest()
        {
            return HttpContext.Current.Request;
        }
    }
}