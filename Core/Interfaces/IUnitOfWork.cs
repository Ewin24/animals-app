using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisRepository Paises { get; }
        ICiudadRepository Ciudades { get; }
        IClienteRepository Clientes { get; }
        ICitaRepository Citas { get; }
        IDepartamentoRepository Departamentos { get; }
        IMascotaRepository Mascotas { get; }
        IRazaRepository Razas { get; }
        IServicioRepository Servicios { get; }
        IClienteTelRepository ClienteTel { get; }
        IClienteDirRepository ClientesDir { get; }
        Task<int> SaveAsync();
    }
}