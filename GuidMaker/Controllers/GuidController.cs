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
        public readonly string _machineName;

        public GuidController()
        {
            _machineName = Environment.MachineName;
        }

        // GET: api/values
        [HttpGet]
        public GuidResponse Get()
        {
            return new GuidResponse
            {
                guid = Guid.NewGuid(),
                hostname = _machineName
            };
        }

    }
}
