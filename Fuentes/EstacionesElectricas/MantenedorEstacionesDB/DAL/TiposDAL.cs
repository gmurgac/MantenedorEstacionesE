using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenedorEstacionesDB.DAL
{
    public class TiposDAL
    {
        public MantenedorEstacionesBDEntities db = new MantenedorEstacionesBDEntities();

        public List<TipoPunto> GetAll()
        {
            return db.TipoPunto.ToList();
        }
    }
}
