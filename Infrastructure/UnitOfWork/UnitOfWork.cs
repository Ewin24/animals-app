using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AnimalsContext _context;
    private PaisRepository _paises;
    private CitaRepository _citas;
    private CiudadRepository _ciudades;
    private DepartamentoRepository _departamentos;
    private ClienteRepository _clientes;
    private MascotaRepository _mascotas;
    private RazaRepository _razas;
    private ClienteTelRepository _clientestel;
    private ClienteDirRepository _clientesdir;
    private ServicioRepository _servicios;

    public IPaisRepository Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public ICiudadRepository Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public IClienteRepository Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IDepartamentoRepository Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IMascotaRepository Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IRazaRepository Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public IServicioRepository Servicios
    {
        get
        {
            if (_servicios == null)
            {
                _servicios = new ServicioRepository(_context);
            }
            return _servicios;
        }
    }

    public IClienteTelRepository ClienteTel
    {
        get
        {
            if (_clientestel == null)
            {
                _clientestel = new ClienteTelRepository(_context);
            }
            return _clientestel;
        }
    }

    public IClienteDirRepository ClientesDir
    {
        get
        {
            if (_clientesdir == null)
            {
                _clientesdir = new ClienteDirRepository(_context);
            }
            return _clientesdir;
        }
    }

    public ICitaRepository Citas
    {
        get
        {
            if (_citas == null)
            {
                _citas = new CitaRepository(_context);
            }
            return _citas;
        }
    }

    public UnitOfWork(AnimalsContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
