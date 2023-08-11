using Microsoft.AspNetCore.Mvc;
using Agendamentos.Global;
namespace Agendamentos.Controllers
{
    [ApiController]
    [Route("api/access")]
    public class AcessController : Controller
    {
        [HttpGet]
        [Route("GetToken")]
        public JsonResult GetToken(string user, string pass)
        {
            try
            {
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
                {
                    Security security = new Security();
                    string token = security.GenerateToken(user, pass);
                    return new JsonResult(new { success = true, token = token });
                }
                else
                {
                    return new JsonResult(new { success = false, msg = "usuario ou senha invalido" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}
