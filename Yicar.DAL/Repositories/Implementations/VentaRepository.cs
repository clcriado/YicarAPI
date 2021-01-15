using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yicar.Core.DTO;
using Yicar.DAL.Models;
using Yicar.DAL.Repositories.Contracts;

namespace Yicar.DAL.Repositories.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        public yicarContext _context { get; set; }

        public IMapper _mapper;


        public VentaRepository(yicarContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<VentaTablaDTO> TableVenta()
        {
            var lista = _context.Ventas.
                Include(venta => venta.IdClienteNavigation).
                Include(venta => venta.IdVehiculoNavigation).
                Include(venta => venta.IdVendedorNavigation).
                    ThenInclude(vendedor=>vendedor.IdUsuarioNavigation).
                ToList();

            return _mapper.Map<ICollection<VentaTablaDTO>>(lista);

        }
    }
}
