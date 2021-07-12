using EstacionesElectricasDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasDAL.DAL
{
    public class EstacionesDAL
    {
        private static List<Estacion> estaciones = new List<Estacion>();
        public void Guardar(Estacion estacion)
        {
            estaciones.Add(estacion);
        }
        public void Modificar(Estacion estacion)
        {
           
        }
        public List<Estacion> GetAll()
        {
            return estaciones;
        }
        public void Remove(int id)
        {
            Estacion e = estaciones.Find(es => es.Id == id);
            estaciones.Remove(e);
        }
    }
}
