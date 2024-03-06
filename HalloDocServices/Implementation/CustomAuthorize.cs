using HalloDocServices.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HalloDocServices.Implementation;

namespace HalloDocServices.Implementation
{
    //[AttributeUsage(AttributeTargets.All)]
    //public class CustomAuthorize : Attribute, IAuthorizationFilter
    //{
    //    private readonly string _role;

    //    public CustomAuthorize(string role = "")
    //    {
    //        _role = role;
    //    }


    //    public void OnAuthorization(AuthorizationFilterContext filtercontext)
    //    {
    //        var jwtService = filtercontext.HttpContext.RequestServices.GetService<IJwtService>();
    //        if (jwtService == null)
    //        {
    //            filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Pateint", action = "patient_login" }));
    //            return;
    //        }
    //        var request = filtercontext.HttpContext.Request;
    //        var token = request.Cookies["Token"];

    //        if (token == null || !jwtService.ValidateToken(token, out JwtSecurityToken jwtSecurityToken))
    //        {
    //            filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "patien_login" }));
    //            return;
    //        }
    //        var roleclaim = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
    //        if (roleclaim == null)
    //        {
    //            filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "patien_login" }));
    //            return;
    //        }
    //        if (String.IsNullOrWhiteSpace(_role) || roleclaim.Value != _role)
    //        {
    //            filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Patient", action = "AccessDenied" }));
    //            return;
    //        }
    //    }
    //}
}
