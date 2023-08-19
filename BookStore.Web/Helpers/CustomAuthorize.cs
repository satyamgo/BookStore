using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BookStore.Web.Helpers
{
    public class CustomAuthorize: Attribute, IAuthorizationFilter
    {
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //check authentication
        if (context.HttpContext.User.Identity.IsAuthenticated)
        {

        }
        else
        {
            context.Result = new RedirectToActionResult("Login", "Account", new { area = "" });
        }
    }
}
}
