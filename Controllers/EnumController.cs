using CrudVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudVeiculos.Controllers
{
    [ApiController]
    [Route("enums")]
    public class EnumsController : ControllerBase
    {
        private readonly IEnumService _enumService;
        public EnumsController(IEnumService enumService)
            => _enumService = enumService;

        [HttpGet]
        public ActionResult<Dictionary<string, List<object>>> GetAll()
        {
            var all = _enumService.GetAllEnums();
            return Ok(all);
        }
    }
}
