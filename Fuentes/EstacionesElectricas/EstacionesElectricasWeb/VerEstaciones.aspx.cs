
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
    public partial class VerEstaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(new EstacionesDAL().GetAll());
            }
        }

        private void CargarTabla(List<Estacion> estaciones)
        {
            estacionesGrid.DataSource = estaciones;
            estacionesGrid.DataBind();
        }
        protected void estacionesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                String idAEliminar = e.CommandArgument.ToString().Trim();
                EstacionesDAL estacionDAL = new EstacionesDAL();
                estacionDAL.Erase(Convert.ToInt32(idAEliminar));
                CargarTabla(new EstacionesDAL().GetAll());
            }
        }
    }
}