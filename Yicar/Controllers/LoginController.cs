using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yicar.BL.Contracts;
using Yicar.Core.DTO;

namespace Yicar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginBL _loginBL { get; set; }

        public LoginController(ILoginBL loginBL)
        {
            _loginBL = loginBL;
        }

        [HttpPost]
        public bool Login(LoginDTO loginDTO)
        {
            return _loginBL.Login(loginDTO);
            
        }
    }
}