
using MantenedorEstacionesDB;
using MantenedorEstacionesDB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionesElectricasWeb
{
    public partial class RegistrarEstacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            dirEstacion.Text = "";
            idEstacion.Text = "";
        }
        protected void ingresarBtn_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt16(idEstacion.Text.Trim());
                string direccion = dirEstacion.Text.Trim();

                Estacion es = new Estacion();
                es.id = id;
                es.direccion = direccion;

                EstacionesDAL estaciones = new EstacionesDAL();
                estaciones.Save(es);

                Limpiar();
            }
        }
    }
}