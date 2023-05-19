using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.IBusinessLogic;

namespace Vidly.WebApi.Filters
{
    // Pueden hacer otro filtro igual pero para la autorización (roles)
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            Guid token = Guid.Empty;

            if (string.IsNullOrEmpty(authorizationHeader) || !Guid.TryParse(authorizationHeader, out token))
            {
                context.Result = new ObjectResult(new { Message = "Authorization header is missing" })
                {
                    StatusCode = 401
                };
            }
            else
            {
                var sessionManager = this.GetSessionService(context);
                var currentUser = sessionManager.GetCurrentUser(token);

                if (currentUser == null)
                {
                    context.Result = new ObjectResult(new { Message = "Unauthorized" })
                    {
                        StatusCode = 401
                    };
                }
            }
        }

        protected ISessionManager GetSessionService(AuthorizationFilterContext context)
        {
            var sessionManagerObject = context.HttpContext.RequestServices.GetService(typeof(ISessionManager));
            var sessionManager = sessionManagerObject as ISessionManager;

            return sessionManager;
        }
    }
}