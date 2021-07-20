using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LiquidPoc.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthTest: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            await Task.Run(() => { }); // só pra não echer o saco no meu teste.

            return Ok(new { msg = "Sucesso!" });
        }

    }
}
