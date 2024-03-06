using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using HalloDocWebDemo.Utils;

namespace HalloDocServices.Implementation
{
    public class AuthManager : IAuthManager
    {

        public class CustomAuthorize : Attribute, IAuthorizationFilter
        {
            private readonly string _role;

            public CustomAuthorize(string role = "")
            {
                _role = role;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var user = SessionUtils.GetLoggedInUser(context.HttpContext.Session);

                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Patient_login" }));
                    return;
                }

                if (!string.IsNullOrEmpty(_role))
                {
                    if (!(user.Role == _role))
                    {
                        context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "AccessDenied" }));
                    }
                }
            }
        }

    }
}
