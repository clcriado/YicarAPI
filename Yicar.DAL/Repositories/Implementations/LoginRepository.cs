using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yicar.Core.DTO;
using Yicar.DAL.Models;
using Yicar.DAL.Repositories.Contracts;

namespace Yicar.DAL.Repositories.Implementations
{
    public class LoginRepository : ILoginRepository
    {

        yicarContext _context { get; set; }

        public LoginRepository(yicarContext context)
        {
            _context = context;
        }

        public bool Login(LoginDTO loginDTO)
        {
            return _context.Usuario.Any(usuario => usuario.Login == loginDTO.Login && usuario.Clave== loginDTO.Clave && usuario.Tipo == "jefe");
        }
    }
}
