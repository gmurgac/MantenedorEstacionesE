using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenedorEstacionesDB.DAL
{
    public class EstacionesDAL
    {
        public MantenedorEstacionesBDEntities db = new MantenedorEstacionesBDEntities();

        public List<Estacion> GetAll()
        {
            return db.Estacion.ToList();
        }

        public void Save(Estacion e)
        {
            db.Estacion.Add(e);
            db.SaveChanges();
        }

        public void Erase(int idEstacion)
        {
            Estacion e = db.Estacion.Find(idEstacion);
            db.Estacion.Remove(e);
            db.SaveChanges();
        }
    }
}
