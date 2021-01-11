using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yicar.Core.DTO;

namespace Yicar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("pepe")]
        public int Login()
        {
            return 4;
        }

        [HttpPost]
        public bool Login2(LoginDTO loginDTO)
        {
            return true;
        }
    }
}