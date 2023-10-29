using Microsoft.AspNetCore.Mvc;
using Persistence.Context;

namespace User.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly RelationalContext _relationalContext;
        private readonly DocumentContext _documentContext;

        public AuthController(ILogger<AuthController> logger, RelationalContext relationalContext, DocumentContext documentContext)
        {
            _logger = logger;
            _relationalContext = relationalContext;
            _documentContext = documentContext;
        }

        [HttpGet]
        public ActionResult<int> Get() { return 1; }

   
    }
}
