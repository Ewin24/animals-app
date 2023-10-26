using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace ApiAnimals.Dtos
{
    public class ClienteDto
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }
        public ClienteDireccion ClienteDireccion { get; set; }
    }
}