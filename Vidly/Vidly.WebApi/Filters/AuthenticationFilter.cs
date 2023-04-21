using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.IBusinessLogic;

namespace Vidly.WebApi.Filters
{
    // Pueden hacer otro filtro igual pero para la autorización (roles)
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionManager _sessionManager;
        // Recibe por inyeccion de dependencia, para esto tengo que registrarlo como
        // service filter
        public AuthenticationFilter(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public virtual void OnAuthorization(AuthorizationFilterContext context)
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
            else
            {
                var currentUser = _sessionManager.GetCurrentUser(token);

                if (currentUser == null)
                {
                    // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
                    context.Result = new ObjectResult(new { Message = "Unauthorized" })
                    {
                        StatusCode = 401
                    };
                }
            }
        }

    }
}