using Evenstigator.API.DAO;
using Evenstigator.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Evenstigator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class EventLogController : Controller
    {
        private ETWContext _etwContext;
        public EventLogController()
        {
            _etwContext = new ETWContext();
        }

        [HttpGet]
        [Route("logs")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IEnumerable<Log> Get([FromQuery]string sortOrder, [FromQuery]int limit)
        {
            return _etwContext.GetAllEventLogs(sortOrder, limit).ToList();
        }
    }
}
