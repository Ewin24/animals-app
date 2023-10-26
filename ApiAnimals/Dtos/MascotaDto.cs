using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAnimals.Dtos
{
    public class MascotaDto
    {
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}