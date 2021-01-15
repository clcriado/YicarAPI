using AutoMapper;
using Yicar.Core.DTO;
using Yicar.DAL.Models;

namespace Yicar
{
    internal class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Ventas, VentaTablaDTO>();
            CreateMap<Cliente, ClienteNombreDTO>();
            CreateMap<Vehiculo, VehiculoNombreDTO>();
            CreateMap<Vendedor, VendedorNombreDTO>();
            CreateMap<Usuario, UsuarioNombreDTO>();
        }
        
    }
}