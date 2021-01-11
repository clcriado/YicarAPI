using System;
using System.Collections.Generic;
using System.Text;
using Yicar.Core.DTO;

namespace Yicar.BL.Contracts
{
    public interface ILoginBL
    {
        bool Login(LoginDTO loginDTO);
    }
}
