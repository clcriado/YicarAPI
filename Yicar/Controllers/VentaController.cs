using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yicar.BL.Contracts;
using Yicar.Core.DTO;

namespace Yicar.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        public IVentasBL _ventaBL { get; set; }

        public VentaController(IVentasBL ventaBL)
        {
            _ventaBL = ventaBL;
        }

        [HttpGet]
        public ICollection<VentaTablaDTO> TableVenta()
        {
            return _ventaBL.TableVenta();

        }

        [HttpGet ("{id}")]
        public VentaTablaDTO TableVenta(int id)
        {
            return _ventaBL.TableVenta(id);

        }
    }
}
