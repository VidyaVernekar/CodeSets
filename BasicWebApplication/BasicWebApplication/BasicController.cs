using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        [HttpGet]
        public string GetTime()
        {
            return DateTime.Now.ToString();
        }
    }
}
