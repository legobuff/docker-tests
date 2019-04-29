using System;
using Microsoft.AspNetCore.Mvc;

namespace GuidMaker.Controllers
{
    public struct GuidResponse
    {
        public Guid guid { get; set; }
        public string hostname { get; set; }
    }

    [Route("api/[controller]")]
    public class GuidController : Controller
    {
        private static bool _fail;
        private readonly string _machineName;

        public GuidController()
        {
            _machineName = Environment.MachineName;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<GuidResponse> Get()
        {
            if (_fail)
            {
                return StatusCode(500);
            }

            return new GuidResponse
            {
                guid = Guid.NewGuid(),
                hostname = _machineName
            };
        }

        [HttpPost]
        [Route("toggleFailure")]
        public ActionResult ToggleFailure()
        {
            _fail = !_fail;
            return Ok();
        }

    }
}
