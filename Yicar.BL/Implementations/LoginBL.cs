using System;
using System.Collections.Generic;
using System.Text;
using Yicar.BL.Contracts;
using Yicar.Core.DTO;
using Yicar.DAL.Repositories.Contracts;

namespace Yicar.BL.Implementations
{
    public class LoginBL : ILoginBL
    {

        public ILoginRepository _loginRepository { get; set; }

        public LoginBL(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public bool Login(LoginDTO loginDTO)
        {
            return _loginRepository.Login(loginDTO);
        }
    }
}
