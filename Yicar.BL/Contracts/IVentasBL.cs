using System;
using System.Collections.Generic;
using System.Text;
using Yicar.Core.DTO;

namespace Yicar.BL.Contracts
{
    public interface IVentasBL
    {
        ICollection<VentaTablaDTO> TableVenta();

    }
}
