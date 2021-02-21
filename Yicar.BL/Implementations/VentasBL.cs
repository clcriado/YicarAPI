using System;
using System.Collections.Generic;
using System.Text;
using Yicar.BL.Contracts;
using Yicar.Core.DTO;
using Yicar.DAL.Repositories.Contracts;

namespace Yicar.BL.Implementations
{
    public class VentasBL : IVentasBL
    {
        public IVentaRepository _ventaRepository { get; set; }

        public VentasBL(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public ICollection<VentaTablaDTO> TableVenta()
        {
            return _ventaRepository.TableVenta();
        }

        public VentaTablaDTO TableVenta(int id)
        {
            return _ventaRepository.TableVenta(id);
        }
    }
}
