using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasDAL.DTO
{
    public enum Tipo
    {
        Dual,Electrico
    }
    public class Punto
    {
        private int id;
        private Tipo tipo;
        private int idEstacion;

        public override string ToString()
        {
            return base.ToString() + "" + id.ToString();
        }

        public int Id { get => id; set => id = value; }
        public Tipo Tipo { get => tipo; set => tipo = value; }
        public int IdEstacion { get => idEstacion; set => idEstacion = value; }
    }
}
