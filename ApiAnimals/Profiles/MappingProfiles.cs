using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAnimals.Dtos;
using AutoMapper;
using Core.Entities;

namespace ApiAnimals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cita, CitaDto>().ReverseMap();
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<ClienteDireccion, ClienteDireccionDto>().ReverseMap();
            CreateMap<ClienteTelefono, ClienteTelefonoDto>().ReverseMap();
            CreateMap<Departamento, DepartamentoDto>().ReverseMap();
            CreateMap<Mascota, MascotaDto>().ReverseMap();
            CreateMap<Pais, PaisDto>().ReverseMap();
            CreateMap<Raza, RazaDto>().ReverseMap();
            CreateMap<Servicio, ServicioDto>().ReverseMap();
        }
    }
}