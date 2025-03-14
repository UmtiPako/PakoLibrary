using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace PakoLibrary.Filter
{
    public class UserFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("id");

            string currentController = context.RouteData.Values["controller"]?.ToString() ?? "";
            string currentAction = context.RouteData.Values["action"]?.ToString() ?? "";

            if (!userId.HasValue && !(currentController == "Admin" && currentAction == "Index"))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Index"}
                });
            }
        }
    }
}