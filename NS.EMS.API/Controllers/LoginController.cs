using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS.EMS.DATABASE.Entities;
using NS.EMS.LOGINBUSSINESS;

namespace NS.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginBussiness _LoginBussiness;
        public LoginController(ILoginBussiness LoginBussiness)
        {
            _LoginBussiness = LoginBussiness;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Login(Login login)
        {
            
            return Ok(_LoginBussiness.GetLogin(login));
        }
    }
}
