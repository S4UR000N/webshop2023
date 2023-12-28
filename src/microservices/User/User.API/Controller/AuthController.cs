using Microsoft.AspNetCore.Mvc;
using Persistence.Context;
using Serilog;
using System.Diagnostics;

namespace User.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RelationalContext _relationalContext;
        //private readonly DocumentContext _documentContext;

        public AuthController(RelationalContext relationalContext/*, DocumentContext documentContext*/)
        {
            _relationalContext = relationalContext;
            //_documentContext = documentContext;
        }

        [HttpGet]
        public ActionResult<int> Get()
        {
            //Log.Information("test123");
            //Log.Information("test12345765");
            Debugger.Break();
            return 1;
        }
    }
}
