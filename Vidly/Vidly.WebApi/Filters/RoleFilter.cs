using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.IBusinessLogic;

namespace Vidly.WebApi.Filters;

public class RoleFilter: Attribute, IAuthorizationFilter
{
    public string RoleNeeded { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
        Guid token = Guid.Empty;

        if (string.IsNullOrEmpty(authorizationHeader) || !Guid.TryParse(authorizationHeader, out token))
        {
            // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
            context.Result = new ObjectResult(new { Message = "Authorization header is missing" })
            {
                StatusCode = 401
            };
        }

        var sessionManager = GetSessionService(context);
        var currentUser = sessionManager.GetCurrentUser(token);

        if (currentUser == null)
        {
            // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
            context.Result = new ObjectResult(new { Message = "Not authenticated" })
            {
                StatusCode = 401
            };
        }
        else if (currentUser.Role != RoleNeeded)
        {
            context.Result = new ObjectResult(new { Message = "Can't perform action" })
            {
                StatusCode = 403
            };
        }
    }
    
    protected ISessionManager GetSessionService(AuthorizationFilterContext context)
    {
        var sessionManagerObject = context.HttpContext.RequestServices.GetService(typeof(ISessionManager));
        var sessionManager = sessionManagerObject as ISessionManager;

        return sessionManager;
    }
}