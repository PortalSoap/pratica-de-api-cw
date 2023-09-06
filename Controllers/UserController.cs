using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teste_de_api.Models;

namespace teste_de_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUsers()
        {
            return Ok();
        }
    }
}
