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

        YicarContext _context { get; set; }

        public LoginRepository(YicarContext context)
        {
            _context = context;
        }

        public bool Login(LoginDTO loginDTO)
        {
            return _context.Usuario.Any(usuario => usuario.NombreUsuario == loginDTO.Usuario && usuario.Contrasena == loginDTO.Contrasena);
        }
    }
}
