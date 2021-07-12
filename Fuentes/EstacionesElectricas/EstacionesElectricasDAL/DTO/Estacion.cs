using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasDAL.DTO
{
    public class Estacion
    {
        private int id;
        private string direccion;

        public int Id { get => id; set => id = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}
