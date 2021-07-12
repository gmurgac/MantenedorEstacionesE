using EstacionesElectricasDAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionesElectricasDAL.DAL
{
    public class PuntosDAL
    {
        private static List<Punto> puntos = new List<Punto>();
        public void Guardar(Punto punto)
        {
            puntos.Add(punto);
        }
        public void Modificar(Punto punto)
        {
            var elementIndex = puntos.FindIndex(i => i.Id == punto.Id);
            puntos[elementIndex] = punto;
        }
        public List<Punto> GetAll()
        {
            return puntos;
        }
        public void Remove(int id)
        {
            Punto e = puntos.Find(es => es.Id == id);
            puntos.Remove(e);
        }

        public DataRow GetPuntoByID(int id)
        {
            DataTable table;
                table = MakeNamesTable();
            DataRow row;
            Punto p = puntos.Find(f => f.Id == id);
            row = table.NewRow();
            row["id"] = p.Id;
            row["tipo"] = p.Tipo;
            row["idEstacion"] = p.IdEstacion;

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
    }
}
