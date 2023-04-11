using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Vidly.IBusinessLogic;
using Vidly.WebApi.Filters;

namespace Vidly.WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionManager _sessionManager;

        public SessionController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] string email, [FromBody] string password)
        {
            try
            {
                var token = _sessionManager.Authenticate(email, password);
                return Ok(new { token = token });
            }
            catch (InvalidCredentialException e)
            {
                return BadRequest(e.Message);
            }
        }

        // En los endpoints que quiero usar autenticación, agrego el filtro, si quiero usarlo en todos los endpoints
        // de un controller lo agrego a nivel de la clase
        [AuthenticationFilter]
        [HttpDelete]
        public IActionResult Logout()
        {
            // TODO: Implementar logout
            return Ok();
        }
    }
}
