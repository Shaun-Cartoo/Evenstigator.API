using Evenstigator.API.DAO;
using Evenstigator.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Evenstigator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventLogController : Controller
    {
        private ETWContext _etwContext;
        public EventLogController()
        {
            _etwContext = new ETWContext();
        }

        [HttpGet]
        [Route("logs")]
        public IEnumerable<Log> Get()
        {
            return _etwContext.GetAllEventLogs().ToList();
        }
    }
}
