using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
  // Servicio
  private readonly ISessionLogic _sessionLogic;

  public AuthorizationFilter(ISessionLogic sessionLogic)
  {
    _sessionLogic = sessionLogic;
  }

  public void OnAuthorization(AuthorizationFilterContext context)
  {
    var token = context.HttpContext.Request.Headers["Authorization"];

    if (String.IsNullOrEmpty(token) || !_sessionLogic.IsTokenValid(token))
    {
      context.Result = new ContentResult()
      {
        StatusCode = 401,
        Content = "Unauthorized"
      };
    }
  }
}
