using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace ApiAnimals.Dtos
{
    public class CitaDto
    {
        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }
        public int IdMascota { get; set; }
        public Mascota Mascotas { get; set; }
    }
}