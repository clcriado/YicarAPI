using System;
using System.Collections.Generic;
using System.Text;
using Yicar.Core.DTO;

namespace Yicar.DAL.Repositories.Contracts
{
    public interface IVentaRepository
    {
        ICollection<VentaTablaDTO> TableVenta();

    }
}
