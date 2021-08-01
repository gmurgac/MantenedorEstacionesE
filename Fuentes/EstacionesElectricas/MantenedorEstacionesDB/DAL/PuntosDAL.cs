using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantenedorEstacionesDB.DAL
{
   public class PuntosDAL
    {
        public MantenedorEstacionesBDEntities db = new MantenedorEstacionesBDEntities();

        public void Save(Punto p)
        {
            db.Punto.Add(p);
            db.SaveChanges();
        }
        public List<Punto> GetAll()
        {
            return db.Punto.ToList();
        }
        public List<Punto> GetAll(int idTipo)
        {
            var puntos = from p in db.Punto
                        where p.idTipo == idTipo
                        select p;
            return puntos.ToList();
        }
        public void Erase(int idPunto)
        {
            Punto p = db.Punto.Find(idPunto);
            db.Punto.Remove(p);
            db.SaveChanges(); //COMMIT
        }

        public DataRow GetPuntoByID(int id)
        {
            DataTable table;
            table = MakeNamesTable();
            DataRow row;
            Punto p = db.Punto.Find(id);
            row = table.NewRow();
            row["id"] = p.id;
            row["tipo"] = p.TipoPunto;
            row["idEstacion"] = p.idEstacion;

            return row;
        }
        private DataTable MakeNamesTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable namesTable = new DataTable("Names");

            // Add three column objects to the table.
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "id";
            idColumn.AutoIncrement = true;
            namesTable.Columns.Add(idColumn);

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "tipo";
            fNameColumn.DefaultValue = "Fname";
            namesTable.Columns.Add(fNameColumn);

            DataColumn lNameColumn = new DataColumn();
            lNameColumn.DataType = System.Type.GetType("System.String");
            lNameColumn.ColumnName = "idEstacion";
            namesTable.Columns.Add(lNameColumn);

            // Create an array for DataColumn objects.
            DataColumn[] keys = new DataColumn[1];
            keys[0] = idColumn;
            namesTable.PrimaryKey = keys;

            // Return the new DataTable.
            return namesTable;
        }

        public void Modify(Punto punto)
        {
            Erase(punto.id);
            Save(punto);
            db.SaveChanges();
        }
    }
}
